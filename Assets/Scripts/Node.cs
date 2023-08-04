using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    //다음의 노드의 위치 정보 저장
    public Transform next;

    //다음 노드의 정보를 넘겨준다
    public Transform GetNext()
    {
        return next;
    }
}
