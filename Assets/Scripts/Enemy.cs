using System.Threading;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //이동속도
    public float speed = 10f;
    //이동 목표
    private Vector3 point1;

    //다음 이동 정보
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
            Debug.Log("도착!!!");
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
                Debug.Log("종점 도착!!!");
                Destroy(gameObject);
                break;
        }
    }
    */
}
