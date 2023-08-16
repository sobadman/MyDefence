using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//메인 카메라 바라보는 기능 구현
public class LookAtCamera : MonoBehaviour
{
    Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        //메인카메라 객체 가져오기
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //메인카메라 바라보기
        transform.LookAt(mainCamera.transform);
    }
}
