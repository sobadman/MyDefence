using System.Collections;
using System.Threading;
using UnityEngine;

public class Turret : MonoBehaviour
{
	//터렛의 공격범위, 터렛 사거리
	public float attackRange = 15.0f;

    public string enemyTag = "Enemy";

    float time = 0f;
    
    public float checkTime = 0.5f;

    float shootTime = 0f;

    public float shoot = 1.0f;

    public Transform target;

    public Transform rotatePart;
    public float turnSpeed = 5f;

    public Transform firePoint;
    public GameObject bulletPrefab;


    // Start is called before the first frame update
    void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
        //0.5초마다 target을 찾도록 한다
        time += Time.deltaTime;
        shootTime += Time.deltaTime;
        if (time > checkTime)
        {
            FindTarget();
            time = 0;
        }
        if(target != null)
        {
            LockOnTarget();
            if (shootTime >= shoot)
            {
                Shoot();
                shootTime = 0;
            }
        }
        
    }

    //게임상의 모든 적들을 찾아 가장 가까운 적을 찾는다
    void FindTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float distance = 0;
        float MinValue = float.MaxValue;
        GameObject nearEnemy = null;
        //가장 가까운 거리 구하기

        //가장 가까운 거리에 있는 GameObject enemy 찾기

        for(int i = 0; i < enemies.Length; i++)
        {
            distance = Vector3.Distance(enemies[i].transform.position, this.transform.position);
            if(distance < MinValue)
            {
                MinValue = distance;
                nearEnemy = enemies[i];
            }

        }

        if( nearEnemy != null && MinValue < attackRange)
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
        GameObject bulletGo = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Destroy(bulletGo, 3f);
        
        Bullet bullet = bulletGo.GetComponent<Bullet>();
        bullet.SetTarget(target);
    }

    void LockOnTarget()
    {
        Vector3 dir = target.position - rotatePart.position;

        Quaternion lookRotation = Quaternion.LookRotation(dir);

        Quaternion qRotation = Quaternion.Lerp(rotatePart.rotation, lookRotation, Time.deltaTime * turnSpeed);

        Vector3 eRotation = qRotation.eulerAngles;

        rotatePart.rotation = Quaternion.Euler(0f, eRotation.y, 0f);
    }

	private void OnDrawGizmosSelected()
	{
        Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, attackRange);
	}


}
