using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    //공격할 대상(적)
    protected Transform target;

    [Header("Attribute")]
    //터렛 회전
    public Transform rotatePart;
    public float turnSpeed = 5f;

    //터렛의 공격범위, 터렛 사거리
    [SerializeField]
    protected float attackRange = 15.0f;

    //enemy 태그
    public string enemyTag = "Enemy";

    //Find 타이머
    public float findTime = 0.5f;
    protected float countdown = 0f; //Find 타이머 전용 시간 누적 변수

    [Header("Shooting")]
    //Shoot 타이머
    public float shootTime = 1.0f;
    protected float countdownShoot = 0f; //Shoot 타이머 전용 시간 누적 변수

    //탄환 발사
    public GameObject bulletPrefab;
    public Transform firePoint;

    // Update is called once per frame
    protected virtual void Update()
    {
        //0.5초마다 target을 찾도록 한다
        countdown += Time.deltaTime;
        if(countdown > findTime)        
        {
            //타이머 실행문
            FindTarget();
            countdown =0f;
        }

        if(target == null)
        {
            return;
        }

        //회전 - 타겟팅 
        LockOnTarget();        

        //1초마다 1발씩 쏘기
        countdownShoot += Time.deltaTime;
        if(countdownShoot > shootTime)
        {
            //타이머 실행문
            Shoot();
            countdownShoot = 0;
        }
    }

    //LockOn
    protected void LockOnTarget()
    {
        Vector3 dir = target.position - this.transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);

        Quaternion qRotation = Quaternion.Lerp(rotatePart.rotation, lookRotation, Time.deltaTime * turnSpeed);

        Vector3 eRotaion = qRotation.eulerAngles;

        rotatePart.rotation = Quaternion.Euler(0f, eRotaion.y, 0f);
    }

    //게임상의 모든 적들을 찾아 가장 가까운 적을 찾는다
    protected void FindTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        
        //가장 가까운 거리 구하기
        //가장 가까운 거리에 있는 Gameobject(enemy)
        float minDistance = float.MaxValue;
        GameObject nearEnemy = null;
        int enemyPos = -1;

        for (int i = 0; i < enemies.Length; i++)
        {
            float distance = Vector3.Distance(this.transform.position, enemies[i].transform.position);
            if(distance < minDistance)
            {
                minDistance = distance;
                nearEnemy = enemies[i];
                enemyPos = i;
            }
        }

        if(nearEnemy != null && minDistance < attackRange)
        {
            target = nearEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    //터렛이 총알 발사하는 함수 - 1초마다 1발씩 쏘기
    void Shoot()
    {
        //Debug.Log("Shoot!!!!!!");
        //탄환을 생성, 탄환에게 타겟을 넘겨준다 - 생성한 오브젝트의 값을 초기화
        GameObject bulletGo = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Destroy(bulletGo, 3f);

        Bullet bullet = bulletGo.GetComponent<Bullet>();
        if(bullet == null)
        {
            //error();
            Debug.Log("Bullet 컴포넌트가 존재하지 않습니다");
            return;
        }
        bullet.SetTarget(target);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, attackRange);
    }
}
