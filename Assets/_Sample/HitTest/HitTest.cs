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
    public float x; //box x��ǥ
    public float y; //box y��ǥ
    public float r;
}

public class HitTest : MonoBehaviour
{
    public Transform target;

    public float moveSpeed = 10f;

	void Start()
	{
		
	}

    void Update()
    {
        this.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        CheckPassPosition(target);
    }

    bool CheckHitBox(MyBox a, MyBox b)
    {
        if(Mathf.Abs(a.x - b.x) < a.w/2 + b.w/2 && Mathf.Abs(a.y - b.y) < a.h/2 + b.h/2)
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }

    bool CheckCircleBox(MyCircle c, MyCircle d)
    {
        //float distX = c.x - d.x;
        //float distY = c.y - d.y;
        //float distance = Mathf.Sqrt(distX*distX + distY*distY);

        //float sumR = c.r + d.r;

        float distX = c.x - d.x;
        float distY = c.y - d.y;
        float distance = distX * distX + distY * distY;

        float sumR = c.r + d.r;

        if (distance <= sumR*sumR)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    bool CheckPassPosition(Transform _target)
    {
        float distance = Vector3.Distance(transform.position, _target.position);
        float distancePerFrame = Time.deltaTime * moveSpeed;
        if(distance <= distancePerFrame)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //���� Ÿ�ٱ����� ���� �Ÿ��� �� �������� �̵��ϴ� �Ÿ����� ������ �浹�̶�� ����
    //

}
