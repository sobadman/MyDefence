using UnityEngine;

public class PlayerMoveTest : MonoBehaviour
{

    public float speed = 5f;
    public Transform point;
    private Vector3 targetPosition;

    public GameObject gTest;

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = point.position;

        TargetTest tTest = point.GetComponent<TargetTest>();
        tTest.a = 50;
        tTest.GetA();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = targetPosition - this.transform.position;
        transform.Translate(dir.normalized * Time.deltaTime * speed);
    }
}
