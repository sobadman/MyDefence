using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float shotSpeed = 10f;

    public string enemyTag = "Enemy";

    public GameObject turret;

    public Transform target;

    public GameObject particlePrefab;

    public void SetTarget(Transform _target)
    {
        target = _target;
    }

    // Start is called before the first frame update
    void Start()
    {

    }
    void Update()
    {
        if(target == null) 
        {
            Destroy(this.gameObject);
            return;
        }
        
        Vector3 dir = target.position - this.transform.position;
        float distancePerFrame = Time.deltaTime * shotSpeed;
        if (dir.magnitude < distancePerFrame)
        {
            HitTarget();
        }
        this.transform.Translate(dir.normalized * Time.deltaTime * shotSpeed, Space.World);

    }

    void HitTarget()
    {
        GameObject particle = Instantiate(particlePrefab, target.position, Quaternion.identity);
        Destroy(target.gameObject);
        Destroy(this.gameObject);
        Destroy(particle, 2f);
    }
}
