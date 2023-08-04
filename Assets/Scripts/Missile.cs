using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : Bullet
{
    //������ ����
    public float damageRange = 7.0f;

    //�� �±�
    public string enemyTag = "Enemy";

    protected override void HitTarget()
    {
        //Ÿ�� ����Ʈ ȿ�� ����
        GameObject effGo = Instantiate(impactEffectPrefab, this.transform.position, Quaternion.identity);
        Destroy(effGo, 2f);

        //���� Ÿ�� ����
        Explosion();

        //�淿 ����        
        Destroy(this.gameObject);
    }


    // enemy Ÿ�ݽ� �̻����� �������� �ݰ� 7�ȿ� �ִ� ��� enemy���� �Ÿ��� ����ؼ� ������ �Դ´�
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
