using System.Collections;
using UnityEngine;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
	public GameObject enemyPrefab;
	float countdown = 0f;
	public float spawnTime = 5f;
	int count = 1;

	public Transform next;

	//카운트다운 텍스트 UI
	public TextMeshProUGUI countdownText;

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
        countdownText.text = (5 - Mathf.FloorToInt(countdown)).ToString();
        if (countdown >= spawnTime)
		{
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
