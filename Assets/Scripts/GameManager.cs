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

    //���ӿ���üũ
    private static bool isGameOver = false;
    public static bool IsGameOver
    {
        get { return isGameOver; }
    }

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
