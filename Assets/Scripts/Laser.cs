using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : Turret
{
    [Header("Use Laser")]
    public ParticleSystem laserImpact;
    public Light impactLight;
    private LineRenderer lineRenderer;

    //�ʴ� 30������
    [SerializeField]
    private float laserDamage = 30;
    //�ӵ� 30% ����
    [SerializeField]
    private float slowRate = 0.3f;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame 
    protected override void Update()
    {
        //0.5�ʸ��� target�� ã���� �Ѵ�
        countdown += Time.deltaTime;
        if (countdown > findTime)
        {
            //Ÿ�̸� ���๮
            FindTarget();
            countdown = 0f;
        }

        if (target == null)
        {
            //�������� �׸��� �ʴ´�
            if (lineRenderer.enabled == true)
            {
                lineRenderer.enabled = false;
                laserImpact.Stop();
                impactLight.enabled = false;
            }
            return;
        }

        //ȸ�� - Ÿ���� 
        LockOnTarget();

        //
        ShootLaser();
    }

    void ShootLaser()
    {
        //������ ��� - 1�ʴ� 30 ������
        float damage = laserDamage * Time.deltaTime;
        Enemy enemy = target.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            enemy.SlowMove(slowRate);
        }

        if (lineRenderer.enabled == false)
        {
            lineRenderer.enabled = true;
            laserImpact.Play();
            impactLight.enabled = true;
        }

        //"������ ���"; - ��������, ������ ����
        lineRenderer.SetPosition(0, firePoint.position); //���� ����
        lineRenderer.SetPosition(1, target.position);    //�� ����

        //������ ����Ʈ ȿ�� - �������� �� ������ ����Ʈ ȿ�� ��ġ
        Vector3 dir = firePoint.position - target.position;
        laserImpact.transform.position = target.position + dir.normalized;
        laserImpact.transform.rotation = Quaternion.LookRotation(dir);
    }
}


/*
Time.deltaTime : �� �������� ���ư��� ���� �ɸ��� �ð�

frame : ������Ʈ �ѹٲ� ���°�
/*
10frame : 1�ʿ� frame�� 10�� ���°�
Time.deltaTime : 0.1�� / 1frame
0.1 * 30
0.1 * 30
0.1 * 30
0.1 * 30
0.1 * 30
0.1 * 30
0.1 * 30
0.1 * 30
0.1 * 30
0.1 * 30
30 * (0.1 + 0.1 + ....)
30 * (1)

2frame : 1�ʿ� frame�� 2�� ���°�
Time.deltaTime : 0.5�� / 1frame
0.5 * 30
0.5 * 30
30 * (0.5 + 0.5)
30 * (1)


50 * Time.deltaTime
*/
