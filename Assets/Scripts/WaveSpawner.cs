using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    float countdown = 0f;
    public float spawnTime = 5f;
    int count = 1;

    public Transform next;

    // Start is called before the first frame update
    void Start()
    {
        GameObject enemyGo = Instantiate(enemyPrefab, this.transform.position, Quaternion.identity);
        enemyGo.GetComponent<Enemy>().SetNext(next);

    }

    // Update is called once per frame
    void Update()
    {
        countdown += Time.deltaTime;
        if (countdown >= spawnTime)
        {
            Debug.Log($"{spawnTime}°¡ Áö³µ´Ù");
            countdown = 0f;
            //Instantiate(enemyPrefab, this.transform.position, Quaternion.identity);
            count += 1;
            StartCoroutine(SpawnEnemy(count));
        }
    }

    IEnumerator SpawnEnemy(int a)
    {
        for(int i = 0;  i < a; i++)
        {
            GameObject enemyGo = Instantiate(enemyPrefab, this.transform.position, Quaternion.identity);
            enemyGo.GetComponent<Enemy>().SetNext(next);
            yield return new WaitForSeconds(0.3f);
        }
    }
}
