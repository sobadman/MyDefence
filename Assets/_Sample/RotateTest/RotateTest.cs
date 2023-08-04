using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTest : MonoBehaviour
{
    //회전속도
    public float turnSpeed = 5f;

    //이동속도
    public float moveSpeed = 5f;

    //float x;
    //목표 지점
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
        //[1-1] RotateAround - 지구의 공전
        //this.transform.RotateAround(target.position, Vector3.up, Time.deltaTime * turnSpeed * 10);

        //목표 방향
        //Vector3 dir = target.position - this.transform.position;
        //방향 벡터로 회전값 얻어오기
        //Quaternion lookRotation = Quaternion.LookRotation(dir);
        //Quaternion qRotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
        //Quaternion에서 euler값 얻어오기
        //Vector3 eRotation = qRotation.eulerAngles;
        //euler값 연산
        //eRotation.x, eRotation.y, eRotation.z
        //euler값 값을 다시 Quaternion으로 적용
        //this.transform.rotation = Quaternion.Euler(0f, eRotation.y, 0f);

        //
        Vector3 dir = target.position - this.transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        //조금씩 이동
        //Quaternion qRotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);        
        //Vector3 eAngles = qRotation.eulerAngles; // 4자리의 수를 3자리의 수로 가져온다
        //eAngles.x, eAngles.y, eAngles.z
        //this.transform.rotation = Quaternion.Euler(0f, eAngles.y, 0f);

        this.transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);

        //직접이동
        //this.transform.rotation = lookRotation;

        //this.transform.Translate(dir * Time.deltaTime * moveSpeed, Space.World);

    }
}
