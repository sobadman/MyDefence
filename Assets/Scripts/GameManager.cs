using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//게임의 전체 Flow를 관리하는 클래스
public class GameManager : MonoBehaviour
{
    //치팅 체크
    private bool isCheating = true;

    //게임오버 UI
    public GameObject gameOverUI;

    //게임오버체크
    private static bool isGameOver = false;
    public static bool IsGameOver
    {
        get { return isGameOver; }
    }

    private void Start()
    {
        //초기화
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

        //게임오버 체크
        if(PlayerStats.Lives <= 0)
        {
            Debug.Log("GameOver!!");
            GameOver();
        }

        //게임오버 치트키
        if (CheckCheatKey(CheatKey.GameOver))
        {
            GameOver();
        }
        //머니치트기
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


    //머니 치팅 - 10만 골드 지급
    void ShowMeTheMoney()
    {
        if (isCheating == false)
            return;

        PlayerStats.AddMoney(100000);
    }

    //레벨업 치팅
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
