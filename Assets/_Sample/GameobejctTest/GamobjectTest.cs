using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SingletonDemo;

public class GamobjectTest : MonoBehaviour
{
    //(2) (객체)정보를 가져오려는 대상의 오브젝트의 (객체)변수(gameobject, transform)를 public으로 선언하고
    //    인스펙트 창에서 드래그앤 드롭으로 가져온다
    public Transform publicObject;

    //(3) GameObject.FindGameObjectsWithTag, GameObject.FindGameObjectWithTag 반환값으로 (객체)정보를 받아 옵니다
    GameObject[] tagObjects;
    GameObject tagObject;

    //(4) 프리팹을 객체로 생성할때(하이라키창에 오브젝트로 올릴때) Instantiate 반환값으로 (객체)정보를 받아 옵니다
    public GameObject prefabObject;

    //(5) 부모 오브젝트를 통해 종속되어 있는 자식오브젝트 배열로 묶어서 접근한다
    //같은 종류, 성격의 오브젝트들을 관리하기위해 부모오브젝트를 만든다
    public Transform parentObejct;
    Transform[] childObjects;

    //(6) Static (정적)멤버에 직접 접근한다
    
    //(7) 싱글톤 - Static, 객체

    // Start is called before the first frame update
    void Start()
    {
        //(1) (객체)정보를 가져오려는 대상의 오브젝트 스크립트를 붙여서 this 를 이용해 접근한다(가져온다)
        //this.gameObject    
        //this.transform       

        //(2) 접근한 객체의 public 한 멤버에게 접근이 가능하다
        //publicObject.GetComponent<AnotherObejct>().DoSomething();

        //(3) 태그를 이용하여 게임 오브젝트를 찾는다
        //tagObjects = GameObject.FindGameObjectsWithTag("Enemy");
        //tagObject = GameObject.FindGameObjectWithTag("Enemy");

        //(4)Instantiate 반환값으로 오브젝트에 접근한다
        //GameObject prefabObjectGo = Instantiate(prefabObject, this.transform.position, Quaternion.identity);

        //(5) parentObejct.GetChild 반환값으로 오브젝트에 접근한다
        /*childObjects = new Transform[parentObejct.childCount];
        for (int i = 0; i < parentObejct.childCount; i++)
        {
            childObjects[i] = parentObejct.GetChild(i);
        }*/

        //(6) 정적 멤버 - 객체를 생성하지 않고 (StaticObject 이름으로) 직접 접근한다
        //StaticObject.number = 10;
        //Debug.Log(StaticObject.number);

        //Singleton 클래스의 객체 생성
        //Singleton instance = new Singleton();
        //instance.GetInstance();

        //정적 멤버 호출
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
