using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ForceTest
{
    public class PlayerMoveTest : MonoBehaviour
    {
        public float moveSpeed = 5f;

        public GameObject bulletPrefab;
        public Transform firePoint;

        public Transform target;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            //wasd 키입력 - 앞뒤좌우 이동구현
            Move();

            //스페이바를 누르면 총에서 총알(bullet)이 발사되도록 구현
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Fire();
            }
        }

        void Fire()
        {
            GameObject bulletGo = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            BulletTest bullet = bulletGo.GetComponent<BulletTest>();
            if(bullet != null)
            {
                Vector3 dir = target.position - this.transform.position;
                bullet.MoveByForce(dir.normalized);
            }

            Destroy(bulletGo, 3f);
        }

        void Move()
        {
            //회전
            Vector3 dir = target.position - this.transform.position;
            transform.rotation = Quaternion.LookRotation(dir);

            //이동
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.back * Time.deltaTime * moveSpeed, Space.World);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.left * Time.deltaTime * moveSpeed, Space.World);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.right * Time.deltaTime * moveSpeed, Space.World);
            }
        }
    }
}