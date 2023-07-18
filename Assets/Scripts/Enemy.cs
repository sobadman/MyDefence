using UnityEngine;

public class Enemy : MonoBehaviour
{
    //�̵��ӵ�
    public float speed = 10f;
    //�̵� ��ǥ
    private Vector3 point1;

    //���� �̵� ����
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
            Debug.Log("����!!!");
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
            Debug.Log("���� ����!!!");
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
