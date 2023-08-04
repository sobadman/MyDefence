using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DamageTest
{
    public class Monster : MonoBehaviour, IDamageable
    {
        //ü��
        public float health;
        //ü�� �ʱⰪ
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
