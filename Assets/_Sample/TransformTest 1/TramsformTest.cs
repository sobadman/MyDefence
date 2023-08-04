using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TramsformTest : MonoBehaviour
{
    public TextMeshProUGUI t00;
    public TextMeshProUGUI t01;
    public TextMeshProUGUI t02;
    public TextMeshProUGUI t03;
    public TextMeshProUGUI t10;
    public TextMeshProUGUI t11;
    public TextMeshProUGUI t12;
    public TextMeshProUGUI t13;
    public TextMeshProUGUI t20;
    public TextMeshProUGUI t21;
    public TextMeshProUGUI t22;
    public TextMeshProUGUI t23;
    public TextMeshProUGUI t30;
    public TextMeshProUGUI t31;
    public TextMeshProUGUI t32;
    public TextMeshProUGUI t33;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(transform.localToWorldMatrix.m00 + ", " + transform.localToWorldMatrix.m01 + ", " + transform.localToWorldMatrix.m02 + ", " + transform.localToWorldMatrix.m03);
        Debug.Log(transform.localToWorldMatrix.m10 + ", " + transform.localToWorldMatrix.m11 + ", " + transform.localToWorldMatrix.m12 + ", " + transform.localToWorldMatrix.m13);
        Debug.Log(transform.localToWorldMatrix.m20 + ", " + transform.localToWorldMatrix.m21 + ", " + transform.localToWorldMatrix.m22 + ", " + transform.localToWorldMatrix.m23);
        Debug.Log(transform.localToWorldMatrix.m30 + ", " + transform.localToWorldMatrix.m31 + ", " + transform.localToWorldMatrix.m32 + ", " + transform.localToWorldMatrix.m33);
    }

    // Update is called once per frame
    void Update()
    {
        t00.text = transform.localToWorldMatrix.m00.ToString();
        t01.text = transform.localToWorldMatrix.m01.ToString();
        t02.text = transform.localToWorldMatrix.m02.ToString();
        t03.text = transform.localToWorldMatrix.m03.ToString();
        t10.text = transform.localToWorldMatrix.m10.ToString();
        t11.text = transform.localToWorldMatrix.m11.ToString();
        t12.text = transform.localToWorldMatrix.m12.ToString();
        t13.text = transform.localToWorldMatrix.m13.ToString();
        t20.text = transform.localToWorldMatrix.m20.ToString();
        t21.text = transform.localToWorldMatrix.m21.ToString();
        t22.text = transform.localToWorldMatrix.m22.ToString();
        t23.text = transform.localToWorldMatrix.m23.ToString();
        t30.text = transform.localToWorldMatrix.m30.ToString();
        t31.text = transform.localToWorldMatrix.m31.ToString();
        t32.text = transform.localToWorldMatrix.m32.ToString();
        t33.text = transform.localToWorldMatrix.m33.ToString();

        //Debug.Log(transform.localToWorldMatrix.m00 + ", " + transform.localToWorldMatrix.m01 + ", " + transform.localToWorldMatrix.m02 + ", " + transform.localToWorldMatrix.m03);
        //Debug.Log(transform.localToWorldMatrix.m10 + ", " + transform.localToWorldMatrix.m11 + ", " + transform.localToWorldMatrix.m12 + ", " + transform.localToWorldMatrix.m13);
        //Debug.Log(transform.localToWorldMatrix.m20 + ", " + transform.localToWorldMatrix.m21 + ", " + transform.localToWorldMatrix.m22 + ", " + transform.localToWorldMatrix.m23);
        //Debug.Log(transform.localToWorldMatrix.m30 + ", " + transform.localToWorldMatrix.m31 + ", " + transform.localToWorldMatrix.m32 + ", " + transform.localToWorldMatrix.m33);
    }
}
