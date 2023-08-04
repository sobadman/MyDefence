using UnityEngine;

public class CameraController : MonoBehaviour
{
    //ī�޶� ��,��, ��,�� �̵��ӵ�
    public float moveSpeed = 5.0f;
    //ī�޶� ��,�Ʒ� �̵� �ӵ�
    public float zoomSpeed = 10.0f;

    //ī�޶� �̵� �Ұ��� - true�� �̵��Ұ���, false�� �̵�����
    public bool isCannotMove = false;
    
    // Update is called once per frame
    void Update()
    {
        if (GameManager.IsGameOver == true)
            return;

        // esc key�� �ѹ� ������, esc key�� �ٽ� �ѹ� ������ : �̵����� <-> �Ұ��� - ��۱��
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


        //ī�޶� �̵� �Ұ���
        if (isCannotMove == true)
        {
            return;
        }

        //w,s,a,d
        //wŰ �� �Ǵ� �� ȭ��ǥ ���� ������ ī�޶� ������ �̵��϶�
        //sŰ �� �Ǵ� �Ʒ� ȭ��ǥ ���� ������ ī�޶� �ڷ� �̵��϶�
        //aŰ �� �Ǵ� <- ȭ��ǥ ���� ������ ī�޶� �·� �̵��϶�
        //dŰ �� �Ǵ� -> ȭ��ǥ ���� ������ ī�޶� ��� �̵��϶�
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

        //���콺�� ��ġ�� �޾ƿ���
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

        //���콺 �� ��ũ�Ѱ��� �Է¹޾� ȭ�� ����, �� �ƿ� ��� ����
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if(scroll != 0)
            Debug.Log($"Mouse ScrollWheel: {scroll}");
        Vector3 upMove = this.transform.position;
        upMove.y -= (scroll * 200) * Time.deltaTime * zoomSpeed;
        //�ִ밪, �ּҰ��� ���� : Mathf.Clamp
        //upMove.y���� 10���ϸ� 10��ȯ, 80�̻��̸� 80��ȯ, 10~80���̰��̸� �״�� ��ȯ
        upMove.y = Mathf.Clamp(upMove.y, 20f, 70f);
        this.transform.position = upMove;
        
    }
}
