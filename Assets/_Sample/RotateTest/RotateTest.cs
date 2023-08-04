using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTest : MonoBehaviour
{
    //ȸ���ӵ�
    public float turnSpeed = 5f;

    //�̵��ӵ�
    public float moveSpeed = 5f;

    //float x;
    //��ǥ ����
    public Transform target;


    // Start is called before the first frame update
    void Start()
    {
        //this.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        //this.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
        //this.transform.rotation = Quaternion.Euler(0f, 0f, 90f);

        Debug.Log(this.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        //x += 1;
        //this.transform.rotation = Quaternion.Euler(x, 0, 0);
        //this.transform.rotation = Quaternion.Euler(0, x, 0);
        //this.transform.rotation = Quaternion.Euler(0, 0, x);

        //[1]Rotate
        //this.transform.Rotate(Vector3.forward * Time.deltaTime * turnSpeed);
        //[1-1] RotateAround - ������ ����
        //this.transform.RotateAround(target.position, Vector3.up, Time.deltaTime * turnSpeed * 10);

        //��ǥ ����
        //Vector3 dir = target.position - this.transform.position;
        //���� ���ͷ� ȸ���� ������
        //Quaternion lookRotation = Quaternion.LookRotation(dir);
        //Quaternion qRotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
        //Quaternion���� euler�� ������
        //Vector3 eRotation = qRotation.eulerAngles;
        //euler�� ����
        //eRotation.x, eRotation.y, eRotation.z
        //euler�� ���� �ٽ� Quaternion���� ����
        //this.transform.rotation = Quaternion.Euler(0f, eRotation.y, 0f);

        //
        Vector3 dir = target.position - this.transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        //���ݾ� �̵�
        //Quaternion qRotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);        
        //Vector3 eAngles = qRotation.eulerAngles; // 4�ڸ��� ���� 3�ڸ��� ���� �����´�
        //eAngles.x, eAngles.y, eAngles.z
        //this.transform.rotation = Quaternion.Euler(0f, eAngles.y, 0f);

        this.transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);

        //�����̵�
        //this.transform.rotation = lookRotation;

        //this.transform.Translate(dir * Time.deltaTime * moveSpeed, Space.World);

    }
}
