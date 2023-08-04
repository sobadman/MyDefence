using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveTest : MonoBehaviour
{
    //�̵��ӵ�
    public float speed = 5f;
    //�̵� ������ ��ġ
    private Vector3 targetPosition;

    //�̵��� ��ǥ ���� ������Ʈ�� Ʈ������ : ��ġ���� �ʿ�
    public Transform target;
    public GameObject gTest;

    // Start is called before the first frame update
    void Start()
    {
        //Ÿ�� ��ġ �ʱ�ȭ
        //targetPosition = new Vector3(-18f, 1.5f, 15f);
        targetPosition = target.position;

        //this.gameObject.GetComponent
        //this.transform.GetComponent

        //
        //TargetTest tTest = new TargetTest();
        //tTest.a = 50; private �� ������
        TargetTest tTest = target.GetComponent<TargetTest>();
        tTest.b = 50; //public�� ����� ������ ���
        Debug.Log(tTest.GetA());

    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.position += new Vector3(0f, 0f, 1f);

        //�̵�
        //���� * Time.deltaTime * ���ǵ�
        Vector3 dir = targetPosition - this.transform.position;
        this.transform.Translate(dir.normalized * Time.deltaTime * speed);


    }
}


/*
���ӿ�����Ʈ (������Ʈ)���� �������� ���

���ӿ�����Ʈ�� transform�� ��ü�� �����ϴ� ���(�������� ���)
1. transform �� �ִ� ������Ʈ�� ��ũ��Ʈ�� �߰��ϰ� �� ��ũ��Ʈ���� this.transform �����Ѵ�
2. (���̶�Űâ�� �����ϴ�)�ٸ� ������Ʈ�� transform�� ��ü�� �����Ϸ��� public ���� ��ü ���� �����ϰ� �ν����� â���� ����� ������ �ȴ�
3. �ڽ� ������Ʈ�� transform ��ü�� �����ϴ� ���: GetChild()



*/

