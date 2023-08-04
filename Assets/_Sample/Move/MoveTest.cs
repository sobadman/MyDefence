using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTest : MonoBehaviour
{
    public float speed = 10f; //1초에 가는 거리

    //이동목표 지점
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
        // 플레이어의 위치를 앞으로 계속 이동 (z축으로 이동)
        // transform.position 연산으로 구현 - Vector3을 이용
        //this.transform.position = this.transform.position + new Vector3(0f, 0f, 1f);
        //앞, 뒤, 좌, 우, 위, 아래로 이동 테스트
        //this.transform.position += Vector3.right; // new Vector3(0f, 0f, 1f);

        //앞:  Vector3(0f, 0f, 1f), Vector3.forward
        //뒤:  Vector3(0f, 0f, -1f), Vector3.back
        //좌:  Vector3(-1f, 0f, 0f), Vector3.left
        //우:  Vector3(1f, 0f, 0f), Vector3.right
        //위:  Vector3(0f, 1f, 0f), Vector3.up
        //아래:  Vector3(0f, -1f, 0f), Vector3.down

        //속도 - 앞 방향으로 1초에 1 unit만큼 이동
        //this.transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime;
        //앞 방향으로 1초에 speed(5)만큼 이동하고 싶다
        //this.transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime * speed;

        //Translate : 이동 함수
        //Time.deltaTime : 이동에서는 동일한 시간에 동일한 거리를 이동하게 해준다
        //speed : 이동의 빠르기를 결정
        //dir(방향) * Time.deltaTime * speed => Vector3
        //this.transform.Translate(Vector3.left * Time.deltaTime * speed);

        //이동 방향 구하기 : (목표지점 - 현재지점), (도착위치 - 현재위치).normalized
        //dir.normalized : 정규화 된 백터, 단위백터, 길이가 1인 백터
        //dir.magnitude : 길이, 크기
        Vector3 dir = targetPosition - this.transform.position;        
        this.transform.Translate(dir.normalized * Time.deltaTime * speed, Space.Self);

        //Space.World, Space.Self        
        //this.transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.World); //글로벌 축 기준으로 이동
        //this.transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.Self);  //로컬 축 기준으로 이동




    }
}


/*
20프레임 = 0.05;


성능이 좋은 컴 (PC1)
10프레임 - 1초에 10만큼 이동 (시간(Time.deltaTime)을 고려하지 않을경우)
Time.deltaTime  : 0.1f - 1초동안 1을 이동

this.transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime; // 0.1씩 증가
this.transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime; // 0.1씩 증가
this.transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime; // 0.1씩 증가
this.transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime; // 0.1씩 증가
this.transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime; // 0.1씩 증가
this.transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime; // 0.1씩 증가
this.transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime; // 0.1씩 증가
this.transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime; // 0.1씩 증가
this.transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime; // 0.1씩 증가
this.transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime; // 0.1씩 증가


성능이 나쁜 컴 (PC2)
2프레임 - 1초에 2만큼 이동 (시간(Time.deltaTime)을 고려하지 않을경우)
Time.deltaTime  : 0.5f  - 1초동안 1을 이동

this.transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime; // 0.5씩 증가
this.transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime; // 0.5씩 증가

0.5프레임 : 2


*/