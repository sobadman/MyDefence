using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputTest : MonoBehaviour
{
    //public RectTransform mText;
    public TextMeshProUGUI mousePos;

    private void Start()
    {
        //��ũ�� ũ��
        Debug.Log($"Screen Width: {Screen.width}, Screen Height : {Screen.height}");
    }

    // Update is called once per frame
    void Update()
    {
        //GetKey
        /*if(Input.GetKey("w")) //Ű�� ������ �ִ���?
        {
            Debug.Log("wŰ�� ������ �ֽ��ϴ�");
        }*/
        /*if(Input.GetKey(KeyCode.W)) //Ű�� ������ �ִ���?
        {
            Debug.Log("WŰ�� ������ �ֽ��ϴ�");
        }
        if(Input.GetKeyDown(KeyCode.A)) //Ű�� ������?
        {
            Debug.Log("AŰ�� �������ϴ�");
        }
        if(Input.GetKeyUp(KeyCode.Space)) //Ű�� �����ٰ� ��������?
        {
            Debug.Log("�����̽�Ű�� �����ٰ� �������ϴ�");
        }*/

        //GetButton
        /*if(Input.GetButton("Jump")) //��ư�� ������ �ִ���?
        {
            Debug.Log("Jump ��ư�� ������ �ֽ��ϴ�");
        }
        if(Input.GetButtonDown("Jump")) //��ư�� ������?
        {
            Debug.Log("Jump ��ư�� �������ϴ�");
        }
        if(Input.GetButtonUp("Jump")) //Ű�� �����ٰ� ��������?
        {
            Debug.Log("Jump ��ư�� �����ٰ� �������ϴ�");
        }*/

        //GetAxis
        /*if(Input.GetButton("Horizontal")) 
        {
            //left : -1 ~ 0
            //right : 0 ~ 1
            //Debug.Log("Horizontal ��: " + Input.GetAxis("Horizontal"));
            Debug.Log("Horizontal ��: " + Input.GetAxisRaw("Horizontal"));
        }
        if (Input.GetButton("Vertical"))
        {
            //down : -1 ~ 0
            //up : 0 ~ 1
            //Debug.Log("Vertical ��: " + Input.GetAxis("Vertical"));
            Debug.Log("Vertical ��: " + Input.GetAxisRaw("Vertical"));
        }*/

        //���콺 ������ ������
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;
        mousePos.text = ((int)mouseX).ToString() + ", " + ((int)mouseY).ToString();

        mousePos.rectTransform.position = new Vector2(mouseX, mouseY);


    }
}
