using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTest : MonoBehaviour
{
    public Rigidbody rb;

    public float power = 100f;

    // Start is called before the first frame update
    void Start()
    {
        //����: ����, ���� ����
        //rb.AddForce(Vector3.forward * power, ForceMode.Impulse);

        //����: ����, ���� ���� 
        //rb.AddForce(transform.forward * power, ForceMode.Impulse);

        //����: ����, ���� ����
        //rb.AddRelativeForce(Vector3.forward * power, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        //rb.AddForce(Vector3.forward * power, ForceMode.Impulse);
    }


    public void MoveByForce()
    {
        rb.AddForce(transform.forward * power, ForceMode.Impulse);
    }

    public void MoveByForce(Vector3 dir)
    {
        rb.AddForce(dir * power, ForceMode.Impulse);
    }

    public void MoveByForce(Vector3 dir, float _power)
    {
        rb.AddForce(dir * _power, ForceMode.Impulse);
    }

}


/*
ForceMode.Force (����, ���� ���)
- �ٶ�, �ڱ�� ó�� ���������� �־����� �� 

ForceMode.Impulse (�ҿ���(1ȸ��), ���� ���)
- ����, Ÿ��, ���������� �����ϴ� ��

ForceMode.Acceleration (����, ���� ����)
- �߷�, ������ ������� ������ ������ �����Ҷ�

ForceMode.VelocityChange (�ҿ���(1ȸ��), ���� ����)
- ���������� ������ �ӵ��� ��ȭ�� ����Ų��
*/
