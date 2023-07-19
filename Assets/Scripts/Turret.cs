using System.Collections;
using System.Threading;
using UnityEngine;

public class Turret : MonoBehaviour
{
	//�ͷ��� ���ݹ���, �ͷ� ��Ÿ�
	public float attackRange = 15.0f;

    public string enemyTag = "Enemy";

    float time = 0f;
    public float checkTime = 0.5f;

    private Transform target;

    public Transform rotatePart;
    public float turnSpeed = 5f;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
        //0.5�ʸ��� target�� ã���� �Ѵ�
        time += Time.deltaTime;
        if(time > checkTime)
        {
            FindTarget();
            time = 0;
        }
        if(target != null)
        {
            Vector3 dir = target.position - rotatePart.position;

            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Debug.Log(lookRotation);

            Quaternion qRotation = Quaternion.Lerp(rotatePart.rotation, lookRotation, Time.deltaTime * turnSpeed);

            Vector3 eRotation = qRotation.eulerAngles;

            rotatePart.rotation = Quaternion.Euler(0f, eRotation.y, 0f);
        }
    }

    //���ӻ��� ��� ������ ã�� ���� ����� ���� ã�´�
    void FindTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float distance = 0;
        float MinValue = float.MaxValue;
        GameObject nearEnemy = null;
        //���� ����� �Ÿ� ���ϱ�

        //���� ����� �Ÿ��� �ִ� GameObject enemy ã��

        for(int i = 0; i < enemies.Length; i++)
        {
            distance = Vector3.Distance(enemies[i].transform.position, this.transform.position);
            if(distance < MinValue)
            {
                MinValue = distance;
                nearEnemy = enemies[i];
            }

        }
        Debug.Log($"�ּҰŸ��� {MinValue}�Դϴ�");

        if( nearEnemy != null && MinValue < attackRange)
        {
            target = nearEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

	private void OnDrawGizmosSelected()
	{
        Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, attackRange);
	}
}
