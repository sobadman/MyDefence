using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : Turret
{
    [Header("Use Laser")]
    public ParticleSystem laserImpact;
    public Light impactLight;
    private LineRenderer lineRenderer;

    //초당 30데미지
    [SerializeField]
    private float laserDamage = 30;
    //속도 30% 감속
    [SerializeField]
    private float slowRate = 0.3f;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame 
    protected override void Update()
    {
        //0.5초마다 target을 찾도록 한다
        countdown += Time.deltaTime;
        if (countdown > findTime)
        {
            //타이머 실행문
            FindTarget();
            countdown = 0f;
        }

        if (target == null)
        {
            //레이저를 그리지 않는다
            if (lineRenderer.enabled == true)
            {
                lineRenderer.enabled = false;
                laserImpact.Stop();
                impactLight.enabled = false;
            }
            return;
        }

        //회전 - 타겟팅 
        LockOnTarget();

        //
        ShootLaser();
    }

    void ShootLaser()
    {
        //데미지 계산 - 1초당 30 데미지
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

        //"레이저 쏘기"; - 시작지점, 끝지점 지정
        lineRenderer.SetPosition(0, firePoint.position); //시작 지점
        lineRenderer.SetPosition(1, target.position);    //끝 지점

        //레이저 임팩트 효과 - 레이저의 끝 지점에 임팩트 효과 위치
        Vector3 dir = firePoint.position - target.position;
        laserImpact.transform.position = target.position + dir.normalized;
        laserImpact.transform.rotation = Quaternion.LookRotation(dir);
    }
}


/*
Time.deltaTime : 한 프레임이 돌아가는 동안 걸리는 시간

frame : 업데이트 한바뀌 도는것
/*
10frame : 1초에 frame이 10번 도는것
Time.deltaTime : 0.1초 / 1frame
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

2frame : 1초에 frame이 2번 도는것
Time.deltaTime : 0.5초 / 1frame
0.5 * 30
0.5 * 30
30 * (0.5 + 0.5)
30 * (1)


50 * Time.deltaTime
*/
