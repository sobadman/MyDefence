using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SerializeTest : MonoBehaviour
{
    public int number = 0;

    public Vector3 dir;

    [SerializeField]
    private string name = "홍길동";

    [SerializeField]
    private StructTest structTest;

    [SerializeField]
    private UnityEvent<int> _event;
}

[System.Serializable] //클래스, 구조체
struct StructTest
{
    public float value1;
    public int value2;
}

/*
Serialization (직렬화) <-> DeSerialization (역직렬화)

Unity 직렬화 
작은 의미에서의 직렬화 : 인스펙터 창에서 데이터 편집이 가능하게 하는것이 직렬화 이다

메타파일 : 
GUID :
FILEID :
*/