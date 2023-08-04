using UnityEngine;

public class CameraController : MonoBehaviour
{
    //카메라 앞,뒤, 좌,우 이동속도
    public float moveSpeed = 5.0f;
    //카메라 위,아래 이동 속도
    public float zoomSpeed = 10.0f;

    //카메라 이동 불가능 - true면 이동불가능, false면 이동가능
    public bool isCannotMove = false;
    
    // Update is called once per frame
    void Update()
    {
        if (GameManager.IsGameOver == true)
            return;

        // esc key를 한번 누르면, esc key를 다시 한번 누르면 : 이동가능 <-> 불가능 - 토글기능
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            /*if(isCannotMove == false)
            {
                isCannotMove = true;
            }
            else
            {
                isCannotMove = false;
            }*/
            isCannotMove = !isCannotMove;
        }


        //카메라 이동 불가능
        if (isCannotMove == true)
        {
            return;
        }

        //w,s,a,d
        //w키 값 또는 위 화살표 값이 들어오면 카메라를 앞으로 이동하라
        //s키 값 또는 아래 화살표 값이 들어오면 카메라를 뒤로 이동하라
        //a키 값 또는 <- 화살표 값이 들어오면 카메라를 좌로 이동하라
        //d키 값 또는 -> 화살표 값이 들어오면 카메라를 우로 이동하라
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) //
        {
            this.transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.Translate(Vector3.back * Time.deltaTime * moveSpeed, Space.World);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Translate(Vector3.left * Time.deltaTime * moveSpeed, Space.World);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Translate(Vector3.right * Time.deltaTime * moveSpeed, Space.World);
        }

        //마우스의 위치값 받아오기
        /*float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;

        if(mouseY < Screen.height && mouseY >= (Screen.height-10))
        {
            this.transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
        }
        if(mouseY > 0 && mouseY <= 10)
        {
            this.transform.Translate(Vector3.back * Time.deltaTime * moveSpeed, Space.World);
        }
        if(mouseX > 0 && mouseX <= 10)
        {
            this.transform.Translate(Vector3.left * Time.deltaTime * moveSpeed, Space.World);
        }
        if(mouseX < Screen.width && mouseX >= (Screen.width-10))
        {
            this.transform.Translate(Vector3.right * Time.deltaTime * moveSpeed, Space.World);
        }*/

        //마우스 휠 스크롤값을 입력받아 화면 줌인, 줌 아웃 기능 구현
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if(scroll != 0)
            Debug.Log($"Mouse ScrollWheel: {scroll}");
        Vector3 upMove = this.transform.position;
        upMove.y -= (scroll * 200) * Time.deltaTime * zoomSpeed;
        //최대값, 최소값에 제한 : Mathf.Clamp
        //upMove.y값이 10이하면 10반환, 80이상이면 80반환, 10~80사이값이면 그대로 반환
        upMove.y = Mathf.Clamp(upMove.y, 20f, 70f);
        this.transform.position = upMove;
        
    }
}
