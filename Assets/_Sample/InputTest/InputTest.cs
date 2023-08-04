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
        //스크린 크기
        Debug.Log($"Screen Width: {Screen.width}, Screen Height : {Screen.height}");
    }

    // Update is called once per frame
    void Update()
    {
        //GetKey
        /*if(Input.GetKey("w")) //키를 누르고 있느냐?
        {
            Debug.Log("w키를 누르고 있습니다");
        }*/
        /*if(Input.GetKey(KeyCode.W)) //키를 누르고 있느냐?
        {
            Debug.Log("W키를 누르고 있습니다");
        }
        if(Input.GetKeyDown(KeyCode.A)) //키를 눌렀냐?
        {
            Debug.Log("A키를 눌렀습니다");
        }
        if(Input.GetKeyUp(KeyCode.Space)) //키를 눌렀다가 떼었느냐?
        {
            Debug.Log("스페이스키를 눌렀다가 떼었습니다");
        }*/

        //GetButton
        /*if(Input.GetButton("Jump")) //버튼이 누르고 있느냐?
        {
            Debug.Log("Jump 버튼을 누르고 있습니다");
        }
        if(Input.GetButtonDown("Jump")) //버튼을 눌렀냐?
        {
            Debug.Log("Jump 버튼을 눌렀습니다");
        }
        if(Input.GetButtonUp("Jump")) //키를 눌렀다가 떼었느냐?
        {
            Debug.Log("Jump 버튼을 눌렀다가 떼었습니다");
        }*/

        //GetAxis
        /*if(Input.GetButton("Horizontal")) 
        {
            //left : -1 ~ 0
            //right : 0 ~ 1
            //Debug.Log("Horizontal 값: " + Input.GetAxis("Horizontal"));
            Debug.Log("Horizontal 값: " + Input.GetAxisRaw("Horizontal"));
        }
        if (Input.GetButton("Vertical"))
        {
            //down : -1 ~ 0
            //up : 0 ~ 1
            //Debug.Log("Vertical 값: " + Input.GetAxis("Vertical"));
            Debug.Log("Vertical 값: " + Input.GetAxisRaw("Vertical"));
        }*/

        //마우스 포지션 얻어오기
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;
        mousePos.text = ((int)mouseX).ToString() + ", " + ((int)mouseY).ToString();

        mousePos.rectTransform.position = new Vector2(mouseX, mouseY);


    }
}
