using System.Collections;
using System.Collections.Generic;
using UnityEngine;

struct MyBox
{
    public float x; //box x��ǥ
    public float y; //box y��ǥ
    public float w; //box width
    public float h; //box height
}

struct MyCircle
{
    public float x; //circle x��ǥ
    public float y; //circle y��ǥ
    public float r; //circle ������
}

public class HitTest : MonoBehaviour
{
    public Transform target;

    public float moveSpeed = 10f;


    private void Update()
    {
        if(CheckPassPosition(target))
        {
            Debug.Log("�浹!!!! + ����");
        }

        this.transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
    }


    //�Ű������� ���� �ΰ��� box�� �浹�ߴ��� üũ
    //�浹�ϸ� true, �浹���� �ʾ����� false
    bool CheckHitBox(MyBox a, MyBox b)
    {
        //�浹�� �Ͼ�� �ʴ� 4���� ���
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

        //4���� ��츦 ������ ������ ��쿡�� �浹 ����
        return true;

        /*
        if(!1 && !2 && !3 && !4)
            return true
        else
            return false
        */
    }

    //�Ű������� ���� �ΰ��� circle�� �浹�ߴ��� üũ
    //�浹�ϸ� true, �浹���� �ʾ����� false
    bool CheckHitCircle(MyCircle c, MyCircle d)
    {
        /*
        //�ο��� �Ÿ�
        float distX = c.x - d.x;
        float distY = c.y - d.y;
        float distance = Mathf.Sqrt(distX*distX + distY*distY);

        //�ο��� �������� ��
        float sumR = c.r + d.r;

        //�ο��� �Ÿ��� �ο��� �������� �պ��� �� ������ �浹�̶�� ����
        if(distance <= sumR)
        {
            return true;
        }
        else
        {
            return false;
        }
        */

        //�ο��� �Ÿ�
        float distX = c.x - d.x;
        float distY = c.y - d.y;
        float distance = distX * distX + distY * distY;

        //�ο��� �������� ��
        float sumR = (c.r + d.r) * (c.r + d.r);

        //�ο��� �Ÿ��� �ο��� �������� �պ��� �� ������ �浹�̶�� ����
        if (distance <= sumR)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //�� ������ �Ÿ��� ���� �Ÿ�(0.5f)�� �ȿ� ������ �浹�̶�� ����
    bool CheckArrivePosition(Transform _target)
    {
        //�Ÿ����ϱ�
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

    //���� Ÿ�ϱ����� ���� �Ÿ��� �� �������� �̵��ϴ� �Ÿ����� ������ �浹 �̶�� ����
    bool CheckPassPosition(Transform _target)
    {
        //Ÿ�ٱ��� ���� �Ÿ�
        float distanceToTarget = Vector3.Distance(_target.position, this.transform.position);
        //�� �����ӿ� �̵��ϴ� �Ÿ�
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
