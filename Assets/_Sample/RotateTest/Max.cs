using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Max : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int[] arr = { 4, 2, 1, 3, 5 };
        Debug.Log($"�ִ밪�� {arr.Max()}�Դϴ�");
        for(int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == arr.Max())
            {
                Debug.Log($"�ִ밪�� {i}�� �濡 �ֽ��ϴ�");
            }
        }
    }

}
