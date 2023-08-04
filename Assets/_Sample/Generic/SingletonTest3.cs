using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonTest3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SingletonTest2.Instance.number = 4567;
        Debug.Log(SingletonTest2.Instance.number);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
