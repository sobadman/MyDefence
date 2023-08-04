using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    //ü��
    private float health;
    //ü�� �ʱⰪ
    [SerializeField]
    private float startHealth = 100f;

    //�����
    [SerializeField]
    private int rewardGold = 50;

    //�̵��ӵ�
    private float speed;
    [SerializeField]
    private float startSpeed = 10f;
    //�̵� ��ǥ ��ġ
    private Vector3 targetPosition;

    //���� �̵� ��ǥ ����
    public Transform next;

    //WayPoints.points �迭�� �ε��� ����
    private int pointsIndex = 0;

    //���� ����Ʈ
    public GameObject deathEffectPrefab;

    // Start is called before the first frame update
    void Start()
    {
        //�ʵ尪 �ʱ�ȭ - �ۺ����� ������ next�� ������ Ÿ�� �ʱ�ȭ        
        targetPosition = WayPoints.points[pointsIndex].position;

        //enemy �ʱ�ȭ
        health = startHealth;
        speed = startSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        //�̵��ϱ�
        //���ⱸ�ϱ�
        Vector3 dir = targetPosition - this.transform.position;
        this.transform.Translate(dir.normalized * Time.deltaTime * speed, Space.World);

        //���� ���� : enemy�� target�� �Ÿ��� 0.5�����̸� �����ߴٰ� ����
        float distance = Vector3.Distance(targetPosition, this.transform.position);
        if(distance <= 0.5f)
        {            
            //GoNextPoint();
            SetNextPoint();
        }

        //�ӵ��� �ʱ�ȭ
        speed = startSpeed;
    }

    //��ǥ ���� ���� �ϸ�
    //���� ��ǥ ������ �ٽ� �����;� �ȴ�
    void GoNextPoint()
    {
        //���� ������ �������� ���� �������� �̵��� ����Ʈ ������ ���� ��� (��ġ����)
        //������ ������Ʈ(next)�� �پ��ִ� Node�� ��ü�� ��������
        Node node = next.GetComponent<Node>();
        //������ ������Ʈ�� node��ü�� ���� ���� �̵��� ����Ʈ�� ������ ������ �����Ѵ�
        next = node.GetNext();

        //���� üũ
        if (next == null) 
        {
            Debug.Log("���� ����");
            //ų
            Destroy(this.gameObject);
        }
        else
        {
            targetPosition = next.position;
        }
    }

    void SetNextPoint()
    {   
        //���� üũ
        if(pointsIndex >= WayPoints.points.Length-1)
        {
            //Debug.Log("���� ����");
            PlayerStats.UseLives(1);

            Destroy(this.gameObject);//ų
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
        //����� ����
        PlayerStats.AddMoney(rewardGold);

        //�״� ����Ʈ ó��
        GameObject eff = Instantiate(deathEffectPrefab, this.transform.position, Quaternion.identity);
        Destroy(eff, 2f);

        Destroy(this.gameObject);
    }
}
