using UnityEngine;

public class Node : MonoBehaviour
{
    //현재 노드 다음의 노드 위치 정보
    public Transform next;

    public Transform GetNext()
    {
        return next;
    }
}
