using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTest : MonoBehaviour
{
    public Rigidbody rb;

    public float power = 100f;

    // Start is called before the first frame update
    void Start()
    {
        //방향: 월드, 앞쪽 뱡향
        //rb.AddForce(Vector3.forward * power, ForceMode.Impulse);

        //방향: 로컬, 앞쪽 뱡향 
        //rb.AddForce(transform.forward * power, ForceMode.Impulse);

        //방향: 로컬, 앞쪽 방향
        //rb.AddRelativeForce(Vector3.forward * power, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        //rb.AddForce(Vector3.forward * power, ForceMode.Impulse);
    }


    public void MoveByForce()
    {
        rb.AddForce(transform.forward * power, ForceMode.Impulse);
    }

    public void MoveByForce(Vector3 dir)
    {
        rb.AddForce(dir * power, ForceMode.Impulse);
    }

    public void MoveByForce(Vector3 dir, float _power)
    {
        rb.AddForce(dir * _power, ForceMode.Impulse);
    }

}


/*
ForceMode.Force (연속, 질량 고려)
- 바람, 자기력 처럼 연속적으로 주어지는 힘 

ForceMode.Impulse (불연속(1회성), 질량 고려)
- 폭발, 타격, 순간적으로 적용하는 힘

ForceMode.Acceleration (연속, 질량 무시)
- 중력, 질량에 상관없이 일저한 가속을 구현할때

ForceMode.VelocityChange (불연속(1회성), 질량 무시)
- 순간적으로 지정한 속도의 변화를 일으킨다
*/
