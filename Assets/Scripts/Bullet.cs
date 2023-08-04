using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //���ݷ�
    protected float attack;
    [SerializeField]
    private float startAttack = 50;

    //���� ���
    private Transform target;

    //�̵� �ӵ�
    public float moveSpeed = 70f;

    //Ÿ�� ����Ʈ ������
    public GameObject impactEffectPrefab;

    public void SetTarget(Transform _target)
    {
        target = _target;
    }

    // Start is called before the first frame update
    void Start()
    {
        //�淿 �ʱ�ȭ
        attack = startAttack;
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            Destroy(this.gameObject);
            return;
        }

        //�̵�
        Vector3 dir = target.position - this.transform.position;
        float distancePerFrame = Time.deltaTime * moveSpeed;
        //���� �Ÿ��� �� �����ӿ� ���� �Ÿ����� ������ ����(�浹) ����
        if(dir.magnitude < distancePerFrame)
        {
            HitTarget();
            return;
        }
        this.transform.Translate(dir.normalized * Time.deltaTime * moveSpeed, Space.World);
        transform.LookAt(target);
    }

    protected virtual void HitTarget()
    {
        //Ÿ�� ����Ʈ ȿ�� ����
        GameObject effGo = Instantiate(impactEffectPrefab, this.transform.position, Quaternion.identity);
        Destroy(effGo, 2f);

        //Ÿ�ٿ� ������ ������
        Damage(target);

        //�淿 ����        
        Destroy(this.gameObject);
    }

    //������ ������ �ֱ�
    protected void Damage(Transform _target)
    {
        //Destroy(enemy.gameObject);

        //���ݷ�(attack)��ŭ �������ֱ�
        /*Enemy enemy = _target.GetComponent<Enemy>();
        if(enemy != null)
        {
            enemy.TakeDamage(attack);
        }*/

        IDamageable damageable = _target.GetComponent<IDamageable>();
        if(damageable != null)
        {
            damageable.TakeDamage(attack);
        }
    }

}
