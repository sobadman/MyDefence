using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;

    //spawn Ÿ�̸�
    public float spawnTime = 5f;
    float countdown = 4f;

    //ù��°, �ι�°,...
    int waveCount = 0;

    //ī��Ʈ�ٿ� �ؽ�Ʈ UI
    public TextMeshProUGUI countdownText;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
