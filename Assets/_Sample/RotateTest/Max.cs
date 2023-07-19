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
        Debug.Log($"최대값은 {arr.Max()}입니다");
        for(int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == arr.Max())
            {
                Debug.Log($"최대값이 {i}번 방에 있습니다");
            }
        }
    }

}
