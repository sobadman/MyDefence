using System.Threading;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //�̵��ӵ�
    public float speed = 10f;
    //�̵� ��ǥ
    private Vector3 point1;

    //���� �̵� ����
    public Transform next;

    //private int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        point1 = new Vector3(0f, 1.5f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = point1 - this.transform.position;
        this.transform.Translate(dir.normalized * Time.deltaTime * speed);

        if(dir.magnitude < 0.01)
        {
            Debug.Log("����!!!");
            //NextPoint();
            GoNextPoint();
        }
    }

    void GoNextPoint()
    {
        Node node = next.GetComponent<Node>();
        next = node.GetNext();
        point1 = next.position;

    }

    /*
    void NextPoint()
    {
        switch (count)
        {
            case 0:
                point1 = new Vector3(15f, 1.5f, 0f);
                count += 1;
                break;
            case 1:
                point1 = new Vector3(15f, 1.5f, 45f);
                count += 1;
                break;
            case 2:
                point1 = new Vector3(30f, 1.5f, 45f);
                count += 1;
                break;
            case 3:
                point1 = new Vector3(30f, 1.5f, 0f);
                count += 1;
                break;
            case 4:
                point1 = new Vector3(45f, 1.5f, 0f);
                count += 1;
                break;
            case 5:
                point1 = new Vector3(45f, 1.5f, 45f);
                count += 1;
                break;
            case 6:
                Debug.Log("���� ����!!!");
                Destroy(gameObject);
                break;
        }
    }
    */
}
