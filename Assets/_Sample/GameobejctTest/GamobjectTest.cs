using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SingletonDemo;

public class GamobjectTest : MonoBehaviour
{
    //(2) (��ü)������ ���������� ����� ������Ʈ�� (��ü)����(gameobject, transform)�� public���� �����ϰ�
    //    �ν���Ʈ â���� �巡�׾� ������� �����´�
    public Transform publicObject;

    //(3) GameObject.FindGameObjectsWithTag, GameObject.FindGameObjectWithTag ��ȯ������ (��ü)������ �޾� �ɴϴ�
    GameObject[] tagObjects;
    GameObject tagObject;

    //(4) �������� ��ü�� �����Ҷ�(���̶�Űâ�� ������Ʈ�� �ø���) Instantiate ��ȯ������ (��ü)������ �޾� �ɴϴ�
    public GameObject prefabObject;

    //(5) �θ� ������Ʈ�� ���� ���ӵǾ� �ִ� �ڽĿ�����Ʈ �迭�� ��� �����Ѵ�
    //���� ����, ������ ������Ʈ���� �����ϱ����� �θ������Ʈ�� �����
    public Transform parentObejct;
    Transform[] childObjects;

    //(6) Static (����)����� ���� �����Ѵ�
    
    //(7) �̱��� - Static, ��ü

    // Start is called before the first frame update
    void Start()
    {
        //(1) (��ü)������ ���������� ����� ������Ʈ ��ũ��Ʈ�� �ٿ��� this �� �̿��� �����Ѵ�(�����´�)
        //this.gameObject    
        //this.transform       

        //(2) ������ ��ü�� public �� ������� ������ �����ϴ�
        //publicObject.GetComponent<AnotherObejct>().DoSomething();

        //(3) �±׸� �̿��Ͽ� ���� ������Ʈ�� ã�´�
        //tagObjects = GameObject.FindGameObjectsWithTag("Enemy");
        //tagObject = GameObject.FindGameObjectWithTag("Enemy");

        //(4)Instantiate ��ȯ������ ������Ʈ�� �����Ѵ�
        //GameObject prefabObjectGo = Instantiate(prefabObject, this.transform.position, Quaternion.identity);

        //(5) parentObejct.GetChild ��ȯ������ ������Ʈ�� �����Ѵ�
        /*childObjects = new Transform[parentObejct.childCount];
        for (int i = 0; i < parentObejct.childCount; i++)
        {
            childObjects[i] = parentObejct.GetChild(i);
        }*/

        //(6) ���� ��� - ��ü�� �������� �ʰ� (StaticObject �̸�����) ���� �����Ѵ�
        //StaticObject.number = 10;
        //Debug.Log(StaticObject.number);

        //Singleton Ŭ������ ��ü ����
        //Singleton instance = new Singleton();
        //instance.GetInstance();

        //���� ��� ȣ��
        //var objectA = Singleton.Instance();
        //var objectB = Singleton.Instance();
        var objectA = Singleton.Instance;
        var objectB = Singleton.Instance;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
