using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    //체력
    private float health;
    //체력 초기값
    [SerializeField]
    private float startHealth = 100f;

    //보상금
    [SerializeField]
    private int rewardGold = 50;

    //이동속도
    private float speed;
    [SerializeField]
    private float startSpeed = 10f;
    //이동 목표 위치
    private Vector3 targetPosition;

    //다음 이동 목표 정보
    public Transform next;

    //WayPoints.points 배열의 인덱스 변수
    private int pointsIndex = 0;

    //데드 이펙트
    public GameObject deathEffectPrefab;

    // Start is called before the first frame update
    void Start()
    {
        //필드값 초기화 - 퍼블릭으로 가져온 next의 정보로 타겟 초기화        
        targetPosition = WayPoints.points[pointsIndex].position;

        //enemy 초기화
        health = startHealth;
        speed = startSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        //이동하기
        //방향구하기
        Vector3 dir = targetPosition - this.transform.position;
        this.transform.Translate(dir.normalized * Time.deltaTime * speed, Space.World);

        //도착 판정 : enemy와 target의 거리가 0.5이하이면 도착했다고 판정
        float distance = Vector3.Distance(targetPosition, this.transform.position);
        if(distance <= 0.5f)
        {            
            //GoNextPoint();
            SetNextPoint();
        }

        //속도를 초기화
        speed = startSpeed;
    }

    //목표 지점 도착 하면
    //다음 목표 지점을 다시 가져와야 된다
    void GoNextPoint()
    {
        //현재 도착한 지점으로 부터 다음으로 이동할 포인트 지점의 정보 담기 (위치정보)
        //도착한 오브젝트(next)에 붙어있는 Node의 객체를 가져오기
        Node node = next.GetComponent<Node>();
        //도착한 오브젝트의 node객체로 부터 다음 이동할 포인트의 정보를 가져와 셋팅한다
        next = node.GetNext();

        //종점 체크
        if (next == null) 
        {
            Debug.Log("종점 도착");
            //킬
            Destroy(this.gameObject);
        }
        else
        {
            targetPosition = next.position;
        }
    }

    void SetNextPoint()
    {   
        //종점 체크
        if(pointsIndex >= WayPoints.points.Length-1)
        {
            //Debug.Log("종점 도착");
            PlayerStats.UseLives(1);

            Destroy(this.gameObject);//킬
            return;
        }

        pointsIndex++;
        //Debug.Log($"pointsIndex: {pointsIndex}");
        targetPosition = WayPoints.points[pointsIndex].position;
    }

    public void SlowMove(float rate)
    {
        speed = startSpeed * (1-rate); // 10 * (1-0.3) = 10 * (0.7) 10 *(0.7)   10*(0.7)
        Debug.Log($"enemy speed : " + speed);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        //Debug.Log($"Health: {health}");

        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        //보상금 지급
        PlayerStats.AddMoney(rewardGold);

        //죽는 이펙트 처리
        GameObject eff = Instantiate(deathEffectPrefab, this.transform.position, Quaternion.identity);
        Destroy(eff, 2f);

        Destroy(this.gameObject);
    }
}
