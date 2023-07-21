using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameobjectTest : MonoBehaviour
{
    //(2) 객체 정보를 가져오는 대상의 오브젝트의 객체 변수를 public으로 선언하고
    //    인스펙트 창에서 드래그앤 드롭으로 가져온다
    public GameObject publicObject;

    // Start is called before the first frame update
    void Start()
    {
        //(1) 객체 정보를 가져오는 대상의 오브젝트 스크립트를 붙여서 this를 이용해 가져온다
        //this.gameObject
        //this.transform

        //(2) 접근한 객체의 public 한 멤버에게 접근이 가능하다
        publicObject.GetComponent<AnotherObject>().DoSomething();

        //GameObject.FindGameObjectsWithTag
        //GameObject.FindGameObjectWithTag
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
