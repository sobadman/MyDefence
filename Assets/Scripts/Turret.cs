using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    //������ ���(��)
    protected Transform target;

    [Header("Attribute")]
    //�ͷ� ȸ��
    public Transform rotatePart;
    public float turnSpeed = 5f;

    //�ͷ��� ���ݹ���, �ͷ� ��Ÿ�
    [SerializeField]
    protected float attackRange = 15.0f;

    //enemy �±�
    public string enemyTag = "Enemy";

    //Find Ÿ�̸�
    public float findTime = 0.5f;
    protected float countdown = 0f; //Find Ÿ�̸� ���� �ð� ���� ����

    [Header("Shooting")]
    //Shoot Ÿ�̸�
    public float shootTime = 1.0f;
    protected float countdownShoot = 0f; //Shoot Ÿ�̸� ���� �ð� ���� ����

    //źȯ �߻�
    public GameObject bulletPrefab;
    public Transform firePoint;

    // Update is called once per frame
    protected virtual void Update()
    {
        //0.5�ʸ��� target�� ã���� �Ѵ�
        countdown += Time.deltaTime;
        if(countdown > findTime)        
        {
            //Ÿ�̸� ���๮
            FindTarget();
            countdown =0f;
        }

        if(target == null)
        {
            return;
        }

        //ȸ�� - Ÿ���� 
        LockOnTarget();        

        //1�ʸ��� 1�߾� ���
        countdownShoot += Time.deltaTime;
        if(countdownShoot > shootTime)
        {
            //Ÿ�̸� ���๮
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

    //���ӻ��� ��� ������ ã�� ���� ����� ���� ã�´�
    protected void FindTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        
        //���� ����� �Ÿ� ���ϱ�
        //���� ����� �Ÿ��� �ִ� Gameobject(enemy)
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

    //�ͷ��� �Ѿ� �߻��ϴ� �Լ� - 1�ʸ��� 1�߾� ���
    void Shoot()
    {
        //Debug.Log("Shoot!!!!!!");
        //źȯ�� ����, źȯ���� Ÿ���� �Ѱ��ش� - ������ ������Ʈ�� ���� �ʱ�ȭ
        GameObject bulletGo = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Destroy(bulletGo, 3f);

        Bullet bullet = bulletGo.GetComponent<Bullet>();
        if(bullet == null)
        {
            //error();
            Debug.Log("Bullet ������Ʈ�� �������� �ʽ��ϴ�");
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
