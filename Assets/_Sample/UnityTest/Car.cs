using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{    
    // Start is called before the first frame update
    void Start()
    {
        //Car car = new Car();
        //car.Update();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    //이동하라
    void Move()
    {
        transform.Translate(Vector3.forward);
    }
}
