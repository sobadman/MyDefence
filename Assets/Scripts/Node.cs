using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    //������ ����� ��ġ ���� ����
    public Transform next;

    //���� ����� ������ �Ѱ��ش�
    public Transform GetNext()
    {
        return next;
    }
}
