using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SerializeTest : MonoBehaviour
{
    public int number = 0;

    public Vector3 dir;

    [SerializeField]
    private string name = "ȫ�浿";

    [SerializeField]
    private StructTest structTest;

    [SerializeField]
    private UnityEvent<int> _event;
}

[System.Serializable] //Ŭ����, ����ü
struct StructTest
{
    public float value1;
    public int value2;
}

/*
Serialization (����ȭ) <-> DeSerialization (������ȭ)

Unity ����ȭ 
���� �ǹ̿����� ����ȭ : �ν����� â���� ������ ������ �����ϰ� �ϴ°��� ����ȭ �̴�

��Ÿ���� : 
GUID :
FILEID :
*/