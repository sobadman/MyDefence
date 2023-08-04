using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour, IDamageable
{
    //ü��
    public float health;
    //ü�� �ʱⰪ
    [SerializeField]
    private float startHealth = 100f;

    // Start is called before the first frame update
    void Start()
    {
        //enemy �ʱ�ȭ
        health = startHealth;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log($"Health: {health}");

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
