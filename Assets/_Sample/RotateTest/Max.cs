using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Max : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int[] arr = { 4, 2, 1, 3, 5 };

        //�ִ밪, �ִ밪�� �ִ� ��ġ
        //�ִ밪�� �ʱⰪ�� ������ ������ �ִ� ���� ���� ������ �ʱ�ȭ
        int maxValue = int.MinValue;
        int maxPos = 0;

        for (int i = 0; i < arr.Length; i++)
        {
            if(arr[i] > maxValue)
            {
                maxValue = arr[i];
                maxPos = i;
            }
        }

        Debug.Log($"�ִ밪�� {maxValue}�Դϴ�");
        Debug.Log($"�ִ밪�� {maxPos}�� �濡 �ֽ��ϴ�");
    }
}

/*
[Q]
�Է� �� int[] arr = { 4, 2, 1, 3, 5 };
[output]
�ִ밪�� 5�Դϴ�
�ִ밪�� 4�� �濡 �ֽ��ϴ�
*/