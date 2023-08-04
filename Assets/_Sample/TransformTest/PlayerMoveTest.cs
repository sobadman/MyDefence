using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveTest : MonoBehaviour
{
    //이동속도
    public float speed = 5f;
    //이동 목적지 위치
    private Vector3 targetPosition;

    //이동할 목표 게임 오브젝트의 트랜스폼 : 위치값이 필요
    public Transform target;
    public GameObject gTest;

    // Start is called before the first frame update
    void Start()
    {
        //타겟 위치 초기화
        //targetPosition = new Vector3(-18f, 1.5f, 15f);
        targetPosition = target.position;

        //this.gameObject.GetComponent
        //this.transform.GetComponent

        //
        //TargetTest tTest = new TargetTest();
        //tTest.a = 50; private 못 가져옴
        TargetTest tTest = target.GetComponent<TargetTest>();
        tTest.b = 50; //public한 멤버를 가져와 사용
        Debug.Log(tTest.GetA());

    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.position += new Vector3(0f, 0f, 1f);

        //이동
        //방향 * Time.deltaTime * 스피드
        Vector3 dir = targetPosition - this.transform.position;
        this.transform.Translate(dir.normalized * Time.deltaTime * speed);


    }
}


/*
게임오브젝트 (컴포넌트)값을 가져오는 방법

게임오브젝트의 transform의 객체에 접근하는 방법(가져오는 방법)
1. transform 에 있는 오브젝트에 스크립트를 추가하고 그 스크립트에서 this.transform 접근한다
2. (하이라키창에 존재하는)다른 오브젝트의 transform의 객체에 접근하려면 public 으로 객체 변수 선언하고 인스펙터 창에서 끌어다 놓으면 된다
3. 자식 오브젝트의 transform 객체에 접근하는 방법: GetChild()



*/

