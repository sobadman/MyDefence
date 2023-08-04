using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DamageTest
{
    public class Monster : MonoBehaviour, IDamageable
    {
        //체력
        public float health;
        //체력 초기값
        [SerializeField]
        private float startHealth = 100f;

        // Start is called before the first frame update
        void Start()
        {
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
}
