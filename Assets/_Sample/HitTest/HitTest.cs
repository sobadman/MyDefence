using System.Collections;
using System.Collections.Generic;
using UnityEngine;

struct MyBox
{
    public float x; //box x좌표
    public float y; //box y좌표
    public float w; //box width
    public float h; //box height
}

struct MyCircle
{
    public float x; //circle x좌표
    public float y; //circle y좌표
    public float r; //circle 반지름
}

public class HitTest : MonoBehaviour
{
    public Transform target;

    public float moveSpeed = 10f;


    private void Update()
    {
        if(CheckPassPosition(target))
        {
            Debug.Log("충돌!!!! + 과금");
        }

        this.transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
    }


    //매개변수로 받은 두개의 box가 충돌했는지 체크
    //충돌하면 true, 충돌하지 않았으면 false
    bool CheckHitBox(MyBox a, MyBox b)
    {
        //충돌이 일어나지 않는 4가지 경우
        //1
        if((a.x - a.w/2) > (b.x + b.w/2))
        {
            return false;
        }
        //2
        if( (a.x + a.w/2) < (b.x -b.w/2))
        {
            return false;
        }
        //3
        if((a.y - a.h/2) > (b.y + b.h/2))
        {
            return false;
        }
        //4
        if ((a.y + a.h/2) < (b.y - b.h/2))
        {
            return false;
        }

        //4가지 경우를 제외한 나머지 경우에는 충돌 판정
        return true;

        /*
        if(!1 && !2 && !3 && !4)
            return true
        else
            return false
        */
    }

    //매개변수로 받은 두개의 circle이 충돌했는지 체크
    //충돌하면 true, 충돌하지 않았으면 false
    bool CheckHitCircle(MyCircle c, MyCircle d)
    {
        /*
        //두원의 거리
        float distX = c.x - d.x;
        float distY = c.y - d.y;
        float distance = Mathf.Sqrt(distX*distX + distY*distY);

        //두원의 반지름의 합
        float sumR = c.r + d.r;

        //두원의 거리가 두원의 반지름의 합보다 더 작으면 충돌이라고 판정
        if(distance <= sumR)
        {
            return true;
        }
        else
        {
            return false;
        }
        */

        //두원의 거리
        float distX = c.x - d.x;
        float distY = c.y - d.y;
        float distance = distX * distX + distY * distY;

        //두원의 반지름의 합
        float sumR = (c.r + d.r) * (c.r + d.r);

        //두원의 거리가 두원의 반지름의 합보다 더 작으면 충돌이라고 판정
        if (distance <= sumR)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //두 지점의 거리가 일정 거리(0.5f)에 안에 있으면 충돌이라고 판정
    bool CheckArrivePosition(Transform _target)
    {
        //거리구하기
        float distance = Vector3.Distance(_target.position, this.transform.position);

        if(distance <= 0.5f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //현재 타켓까지의 남은 거리가 한 프레임이 이동하는 거리보다 작을때 충돌 이라고 판정
    bool CheckPassPosition(Transform _target)
    {
        //타겟까지 남은 거리
        float distanceToTarget = Vector3.Distance(_target.position, this.transform.position);
        //한 프레임에 이동하는 거리
        float distancePerFrame = Time.deltaTime * moveSpeed;

        if(distanceToTarget <= distancePerFrame)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
