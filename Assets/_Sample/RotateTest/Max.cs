using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Max : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int[] arr = { 4, 2, 1, 3, 5 };

        //최대값, 최대값이 있는 위치
        //최대값의 초기값은 변수가 가질수 있는 가장 작은 값으로 초기화
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

        Debug.Log($"최대값은 {maxValue}입니다");
        Debug.Log($"최대값이 {maxPos}번 방에 있습니다");
    }
}

/*
[Q]
입력 값 int[] arr = { 4, 2, 1, 3, 5 };
[output]
최대값은 5입니다
최대값이 4번 방에 있습니다
*/