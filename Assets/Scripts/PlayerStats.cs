using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//플레이어의 데이터를 관리하는 클래스 - 기능 구현,
public class PlayerStats : MonoBehaviour
{
    //소지금
    private static int money;

    //읽기 전용
    public static int Money
    {
        get { return money; }
    }

    //초기 소지금
    [SerializeField]
    private int startMoeny = 400;

    //라이프
    private static int lives;

    //읽기 전용
    public static int Lives
    {
        get { return lives; }
    }

    //초기 라이프
    [SerializeField]
    private int startLives = 10;

    //라운드(Wave)
    private static int rounds;

    public static int Rounds
    {
        get { return rounds; }
        set { rounds = value; }
    }

    private void Start()
    {
        //초기화 - 소지금 지급, 라이프 초기값
        money = startMoeny;
        lives = startLives;
        rounds = 0;
        Debug.Log($"소지금 {startMoeny}을 지급 하였습니다");
    }

    //돈을 버는것
    public static void AddMoney(int amount)
    {
        money += amount;
    }

    //돈을 쓰는것
    public static bool UseMoney(int amount)
    {
        //소지금 체크
        if (money < amount)
        {
            Debug.Log("돈이 부족 합니다");
            return false;
        }

        money -= amount;
        return true;
    }

    //소지금 잔고 확인
    public static bool HasMoney(int amount)
    {
        if (money < amount)
        {
            return false;
        }

        return true;
    }

    //라이프 추가
    public static void AddLives(int amount)
    {
        lives += amount;
    }

    //라이프 사용
    public static void UseLives(int amount)
    {
        lives -= amount;

        if(lives <= 0)
        {
            lives = 0;
        }
    }

}
