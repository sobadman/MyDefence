using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameobjectTest : MonoBehaviour
{
    //(2) ��ü ������ �������� ����� ������Ʈ�� ��ü ������ public���� �����ϰ�
    //    �ν���Ʈ â���� �巡�׾� ������� �����´�
    public GameObject publicObject;

    // Start is called before the first frame update
    void Start()
    {
        //(1) ��ü ������ �������� ����� ������Ʈ ��ũ��Ʈ�� �ٿ��� this�� �̿��� �����´�
        //this.gameObject
        //this.transform

        //(2) ������ ��ü�� public �� ������� ������ �����ϴ�
        publicObject.GetComponent<AnotherObject>().DoSomething();

        //GameObject.FindGameObjectsWithTag
        //GameObject.FindGameObjectWithTag
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
