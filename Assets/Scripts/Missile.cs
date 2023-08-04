using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : Bullet
{
    //데미지 범위
    public float damageRange = 7.0f;

    //적 태그
    public string enemyTag = "Enemy";

    protected override void HitTarget()
    {
        //타격 이펙트 효과 구현
        GameObject effGo = Instantiate(impactEffectPrefab, this.transform.position, Quaternion.identity);
        Destroy(effGo, 2f);

        //범위 타겟 제거
        Explosion();

        //뷸렛 제거        
        Destroy(this.gameObject);
    }


    // enemy 타격시 미사일을 기준으로 반경 7안에 있는 모든 enemy들이 거리에 비례해서 데미지 입는다
    void Explosion()
    {
        if (damageRange <= 0)
            return;

        Collider[] colliders = Physics.OverlapSphere(this.transform.position, damageRange);
        foreach (Collider collider in colliders)
        {
            IDamageable damageable = collider.GetComponent<IDamageable>();
            if(damageable != null)
            {
                float distance = Vector3.Distance(this.transform.position, collider.transform.position);
                float damage = attack * ((7-distance) / damageRange);
                if(damage > 0)
                {
                    damageable.TakeDamage(damage);
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, damageRange);
    }
}
