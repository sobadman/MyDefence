using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour, IDamageable
{
    //체력
    public float health;
    //체력 초기값
    [SerializeField]
    private float startHealth = 100f;

    // Start is called before the first frame update
    void Start()
    {
        //enemy 초기화
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
