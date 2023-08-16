using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnManager : MonoBehaviour
{
    //현재 맵상에서 살아있는 적의 숫자
    public static int enemyAlive = 0;

    //웨이브 데이터(적프리팹, 생산할 숫자, 생산 간격)
    public Wave[] waves;

    //첫번째, 두번째,...
    int waveCount = 0;

    //
    //public GameObject enemyPrefab;

    //spawn 타이머
    public float spawnTime = 5f;
    float countdown = 4f;

    //카운트다운 텍스트 UI
    public TextMeshProUGUI countdownText;

    //
    public GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        enemyAlive = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //현재 맵상에 적이 존재하면 타이머와 스폰을 막는다
        if (enemyAlive > 0)
            return;

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
        PlayerStats.Rounds++;

        Wave wave = waves[waveCount];

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemyPrefab);
            yield return new WaitForSeconds(wave.dealyTime);
        }

        //마지막 웨이브 검사
        if (waveCount < waves.Length - 1)
        {
            waveCount++;
        }
        else
        {   
            gameManager.LevelClear();
            this.enabled = false;
        }
    }

    void SpawnEnemy(GameObject prefab)
    {
        Instantiate(prefab, this.transform.position, Quaternion.identity);

        enemyAlive++;
    }
}
