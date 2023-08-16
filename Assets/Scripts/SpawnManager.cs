using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnManager : MonoBehaviour
{
    //���� �ʻ󿡼� ����ִ� ���� ����
    public static int enemyAlive = 0;

    //���̺� ������(��������, ������ ����, ���� ����)
    public Wave[] waves;

    //ù��°, �ι�°,...
    int waveCount = 0;

    //
    //public GameObject enemyPrefab;

    //spawn Ÿ�̸�
    public float spawnTime = 5f;
    float countdown = 4f;

    //ī��Ʈ�ٿ� �ؽ�Ʈ UI
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
        //���� �ʻ� ���� �����ϸ� Ÿ�̸ӿ� ������ ���´�
        if (enemyAlive > 0)
            return;

        //Ÿ�̸� ����
        countdown += Time.deltaTime;       
        if(countdown >= spawnTime)
        {
            //5�ʸ��� ���๮
            StartCoroutine(SpawnWave());

            countdown = 0f;
        }

        //ī��Ʈ �ٿ� �ؽ�Ʈ UI ����
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

        //������ ���̺� �˻�
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
