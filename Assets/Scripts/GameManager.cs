using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//������ ��ü Flow�� �����ϴ� Ŭ����
public class GameManager : MonoBehaviour
{
    //ġ�� üũ
    private bool isCheating = true;

    //���ӿ��� UI
    public GameObject gameOverUI;

    //���� üũ
    public static bool isReady = true;

    //���ӿ���üũ
    private static bool isGameOver = false;
    public static bool IsGameOver
    {
        get { return isGameOver; }
    }

    //���� ����
    [SerializeField]
    private int nextLevel = 2;

    private void Start()
    {
        //�ʱ�ȭ
        isGameOver = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (isGameOver == true)
        {
            Debug.Log("isGameOver true");
            return;
        }

        //���ӿ��� üũ
        if(PlayerStats.Lives <= 0)
        {
            Debug.Log("GameOver!!");
            GameOver();
        }

        //���ӿ��� ġƮŰ
        if (CheckCheatKey(CheatKey.GameOver))
        {
            GameOver();
        }
        //�Ӵ�ġƮ��
        if (CheckCheatKey(CheatKey.Money))
        {
            ShowMeTheMoney();
        }
    }

    public void LevelClear()
    {
        //���� ����� ������ �����´�
        int nowLevel = PlayerPrefs.GetInt("NowLevel", 1);
        if(nextLevel > nowLevel)
        {
            PlayerPrefs.SetInt("NowLevel", nextLevel);
        }
        
        Debug.Log($"�����ϴ� nextLevel: " + nextLevel);
        
    }

    void GameOver()
    {
        isGameOver = true;
        gameOverUI.SetActive(true);
    }


    //�Ӵ� ġ�� - 10�� ��� ����
    void ShowMeTheMoney()
    {
        if (isCheating == false)
            return;

        PlayerStats.AddMoney(100000);
    }

    //������ ġ��
    void Levelup100()
    {
        if (isCheating == false)
            return;

        //level += 100
    }

    bool CheckCheatKey(CheatKey key)
    {
        if (isCheating == false)
            return false;

        switch (key)
        {
            case CheatKey.Money:
                if (Input.GetKeyDown(KeyCode.M))
                {
                    return true;
                }
                break;
            case CheatKey.GameOver:
                if (Input.GetKeyDown(KeyCode.O))
                {
                    return true;
                }
                break;
        }

        return false;
    }

}

public enum CheatKey
{
    Money,
    Level,
    GameOver
}
