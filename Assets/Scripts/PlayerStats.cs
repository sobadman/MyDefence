using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�÷��̾��� �����͸� �����ϴ� Ŭ���� - ��� ����,
public class PlayerStats : MonoBehaviour
{
    //������
    private static int money;

    //�б� ����
    public static int Money
    {
        get { return money; }
    }

    //�ʱ� ������
    [SerializeField]
    private int startMoeny = 400;

    //������
    private static int lives;

    //�б� ����
    public static int Lives
    {
        get { return lives; }
    }

    //�ʱ� ������
    [SerializeField]
    private int startLives = 10;

    //����(Wave)
    private static int rounds;

    public static int Rounds
    {
        get { return rounds; }
        set { rounds = value; }
    }

    private void Start()
    {
        //�ʱ�ȭ - ������ ����, ������ �ʱⰪ
        money = startMoeny;
        lives = startLives;
        rounds = 0;
        Debug.Log($"������ {startMoeny}�� ���� �Ͽ����ϴ�");
    }

    //���� ���°�
    public static void AddMoney(int amount)
    {
        money += amount;
    }

    //���� ���°�
    public static bool UseMoney(int amount)
    {
        //������ üũ
        if (money < amount)
        {
            Debug.Log("���� ���� �մϴ�");
            return false;
        }

        money -= amount;
        return true;
    }

    //������ �ܰ� Ȯ��
    public static bool HasMoney(int amount)
    {
        if (money < amount)
        {
            return false;
        }

        return true;
    }

    //������ �߰�
    public static void AddLives(int amount)
    {
        lives += amount;
    }

    //������ ���
    public static void UseLives(int amount)
    {
        lives -= amount;

        if(lives <= 0)
        {
            lives = 0;
        }
    }

}
