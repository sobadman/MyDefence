using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTest : MonoBehaviour
{
    public float speed = 10f; //1�ʿ� ���� �Ÿ�

    //�̵���ǥ ����
    Vector3 targetPosition = new Vector3(7.0f, 1.5f, 8.0f);

    // Start is called before the first frame update
    void Start()
    {
        //this.transform.position = new Vector3(-5.0f, 1.5f, 0f);
        //Debug.Log(this.transform.position);
        //this.transform.position = targetPosition;
    }

    // Update is called once per frame
    void Update()
    {
        // �÷��̾��� ��ġ�� ������ ��� �̵� (z������ �̵�)
        // transform.position �������� ���� - Vector3�� �̿�
        //this.transform.position = this.transform.position + new Vector3(0f, 0f, 1f);
        //��, ��, ��, ��, ��, �Ʒ��� �̵� �׽�Ʈ
        //this.transform.position += Vector3.right; // new Vector3(0f, 0f, 1f);

        //��:  Vector3(0f, 0f, 1f), Vector3.forward
        //��:  Vector3(0f, 0f, -1f), Vector3.back
        //��:  Vector3(-1f, 0f, 0f), Vector3.left
        //��:  Vector3(1f, 0f, 0f), Vector3.right
        //��:  Vector3(0f, 1f, 0f), Vector3.up
        //�Ʒ�:  Vector3(0f, -1f, 0f), Vector3.down

        //�ӵ� - �� �������� 1�ʿ� 1 unit��ŭ �̵�
        //this.transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime;
        //�� �������� 1�ʿ� speed(5)��ŭ �̵��ϰ� �ʹ�
        //this.transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime * speed;

        //Translate : �̵� �Լ�
        //Time.deltaTime : �̵������� ������ �ð��� ������ �Ÿ��� �̵��ϰ� ���ش�
        //speed : �̵��� �����⸦ ����
        //dir(����) * Time.deltaTime * speed => Vector3
        //this.transform.Translate(Vector3.left * Time.deltaTime * speed);

        //�̵� ���� ���ϱ� : (��ǥ���� - ��������), (������ġ - ������ġ).normalized
        //dir.normalized : ����ȭ �� ����, ��������, ���̰� 1�� ����
        //dir.magnitude : ����, ũ��
        Vector3 dir = targetPosition - this.transform.position;        
        this.transform.Translate(dir.normalized * Time.deltaTime * speed, Space.Self);

        //Space.World, Space.Self        
        //this.transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.World); //�۷ι� �� �������� �̵�
        //this.transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.Self);  //���� �� �������� �̵�




    }
}


/*
20������ = 0.05;


������ ���� �� (PC1)
10������ - 1�ʿ� 10��ŭ �̵� (�ð�(Time.deltaTime)�� ������� �������)
Time.deltaTime  : 0.1f - 1�ʵ��� 1�� �̵�

this.transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime; // 0.1�� ����
this.transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime; // 0.1�� ����
this.transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime; // 0.1�� ����
this.transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime; // 0.1�� ����
this.transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime; // 0.1�� ����
this.transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime; // 0.1�� ����
this.transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime; // 0.1�� ����
this.transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime; // 0.1�� ����
this.transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime; // 0.1�� ����
this.transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime; // 0.1�� ����


������ ���� �� (PC2)
2������ - 1�ʿ� 2��ŭ �̵� (�ð�(Time.deltaTime)�� ������� �������)
Time.deltaTime  : 0.5f  - 1�ʵ��� 1�� �̵�

this.transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime; // 0.5�� ����
this.transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime; // 0.5�� ����

0.5������ : 2


*/