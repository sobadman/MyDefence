using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���� ī�޶� �ٶ󺸴� ��� ����
public class LookAtCamera : MonoBehaviour
{
    Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        //����ī�޶� ��ü ��������
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //����ī�޶� �ٶ󺸱�
        transform.LookAt(mainCamera.transform);
    }
}
