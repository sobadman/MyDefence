using UnityEngine;

public class Enemy : MonoBehaviour
{
    //이동속도
    public float speed = 10f;
    //이동 목표
    private Vector3 point1;

    //다음 이동 정보
    public Transform next;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = point1 - this.transform.position;
        this.transform.Translate(dir.normalized * Time.deltaTime * speed);

        if (dir.magnitude < 0.01)
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
        if (next == null)
        {
            Debug.Log("종점 도착!!!");
            Destroy(this.gameObject);
        }
        else
        {
            point1 = next.position;
        }

    }


    public void SetNext(Transform _next)
    {
        next = _next;
        point1 = next.position;
    }

}
