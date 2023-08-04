using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //공격력
    protected float attack;
    [SerializeField]
    private float startAttack = 50;

    //공격 대상
    private Transform target;

    //이동 속도
    public float moveSpeed = 70f;

    //타격 이펙트 프리팹
    public GameObject impactEffectPrefab;

    public void SetTarget(Transform _target)
    {
        target = _target;
    }

    // Start is called before the first frame update
    void Start()
    {
        //뷸렛 초기화
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

        //이동
        Vector3 dir = target.position - this.transform.position;
        float distancePerFrame = Time.deltaTime * moveSpeed;
        //남은 거리가 한 프레임에 가는 거리보다 작으면 도착(충돌) 판정
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
        //타격 이펙트 효과 구현
        GameObject effGo = Instantiate(impactEffectPrefab, this.transform.position, Quaternion.identity);
        Destroy(effGo, 2f);

        //타겟에 데미지 입히기
        Damage(target);

        //뷸렛 제거        
        Destroy(this.gameObject);
    }

    //적에게 데미지 주기
    protected void Damage(Transform _target)
    {
        //Destroy(enemy.gameObject);

        //공격력(attack)만큼 데미지주기
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
