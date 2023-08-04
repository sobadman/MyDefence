using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;

    //spawn 타이머
    public float spawnTime = 5f;
    float countdown = 4f;

    //첫번째, 두번째,...
    int waveCount = 0;

    //카운트다운 텍스트 UI
    public TextMeshProUGUI countdownText;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //타이머 구현
        countdown += Time.deltaTime;       
        if(countdown >= spawnTime)
        {
            //5초마다 실행문
            StartCoroutine(SpawnWave());

            countdown = 0f;
        }

        //카운트 다운 텍스트 UI 적용
        countdownText.text = Mathf.FloorToInt(countdown).ToString();

    }

    IEnumerator SpawnWave()
    {
        waveCount++;
        PlayerStats.Rounds++;
        
        //Debug.Log($"waveCount: {waveCount}");

        for (int i = 0; i < waveCount; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, this.transform.position, Quaternion.identity);
    }
}
