using UnityEngine;

public class MoveTest : MonoBehaviour
{
    float speed = 10f;

    Vector3 targetPosition = new Vector3 (7.0f, 1.5f, 8.0f);

	// Start is called before the first frame update
	void Start()
	{
        Debug.Log(this.transform.position);
	}

	// Update is called once per frame
	void Update()
	{
        //this.transform.position += new Vector3(0f, 0f, 1f) * speed * Time.deltaTime;
        //this.transform.position += Vector3.forward * speed * Time.deltaTime;

        //this.transform.Translate(Vector3.left * Time.deltaTime * speed);

        //이동 방향 구하기 : 도착위치 - 현재위치
        //dir.normalized : 정규화 벡터, 단위벡터
        //dir.magnitude : 크기, 스칼라
        //Vector3 dir = targetPosition - this.transform.position;
        //this.transform.position = dir.normalized * Time.deltaTime;

        //this.transform.Translate (dir.normalized * Time.deltaTime * speed);

        //Space.World, Space.Self
        this.transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.World);
        this.transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.Self);
    }
}


/*
성능이 좋은 컴




*/