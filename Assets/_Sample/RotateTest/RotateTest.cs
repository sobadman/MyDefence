using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTest : MonoBehaviour
{
	public float turnSpeed = 5f;

    public float moveSpeed = 5f;

    public Transform target;

	//float x = 0;
	// Start is called before the first frame update
	void Start()
	{
		//this.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
	}

	// Update is called once per frame
	void Update()
	{
        //x += 1;
        //this.transform.rotation = Quaternion.Euler(0f, x, 0f);

        //this.transform.Rotate(Vector3.right * turnSpeed * Time.deltaTime);

        //this.transform.RotateAround(target.position, Vector3.up, turnSpeed * Time.deltaTime);


        //Vector3 dir = target.position - this.transform.position;

        //Quaternion lookRotation = Quaternion.LookRotation(dir);

        //this.transform.rotation = lookRotation;
        //Quaternion qRotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime);

        //Vector3 eRotation = qRotation.eulerAngles;

        //this.transform.rotation = Quaternion.Euler(0f, eRotation.y, 0f);

        //¿Ãµø
        Vector3 dir = target.position - this.transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        this.transform.rotation = lookRotation;
        this.transform.Translate(dir.normalized * Time.deltaTime * moveSpeed, Space.World);


	}
}
