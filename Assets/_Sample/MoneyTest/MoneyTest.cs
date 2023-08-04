using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MoneyTest : MonoBehaviour
{
    //������
    private int gold;

    [SerializeField]
    private int startGold = 100000;

    //������ UI
    public TextMeshProUGUI goldText;

    //1000, 9000 ��ư
    public Button button1000;
    public Button button9000;

    private void Start()
    {
        //�ʱ�ȭ
        InitData();

    }


    private void Update()
    {
        //button1000
        if(HasMoney(1000) == true)
        {
            button1000.interactable = true;
            //button1000.image.color = Color.white;
        } 
        else
        {
            button1000.interactable = false;
            //button1000.image.color = Color.red;
        }

        //button9000
        if (HasMoney(9000) == true)
        {
            button9000.interactable = true;
            //button9000.image.color = Color.white;
        }
        else
        {
            button9000.interactable = false;
            //button9000.image.color = Color.red;
        }


        //������ UI ����
        goldText.text = gold.ToString() + " Gold";
    }


    //���� ���°� : ���, ����Ʈ, ĳ�� ����
    public void AddMoney(int amount)
    {
        gold += amount;
    }

    //���� ���°� : ������ ����, ������ ��� ���
    //�������� �����Ҷ� - ���Ž���, fasle ��ȯ 
    //�������� ����Ҷ� - ���ż���, true ��ȯ
    public bool UseMoney(int amount)
    {
        //������ üũ
        if(gold < amount)
        {
            Debug.Log("���� ���� �մϴ�");
            return false;
        }

        gold -= amount;
        return true;
    }

    //������ �ܰ� Ȯ��
    public bool HasMoney(int amount)
    {
        if(gold < amount)
        {
            return false;
        }

        return true;
    }


    //1000�� ����
    public void Save1000()
    {
        Debug.Log("1000���� ���� �߽��ϴ�");
        AddMoney(1000);
    }

    //1000�� ���� - hp ���� ����
    public void Purchase1000()
    {
        if (UseMoney(1000) == true)
        {
            //���� ���� ����
            Debug.Log($"���� �������� ���� �߽��ϴ�");
        }
    }

    //9000�� ���� - �ܰ� ����
    public void Purchase9000()
    {
        if (UseMoney(9000) == true)
        {
            //���� ���� ����
            Debug.Log($"�ܰ� �������� ���� �߽��ϴ�");
        }
    }

    //������ �ʱ�ȭ �Լ�
    void InitData()
    {
        gold = startGold;
        Debug.Log($"�������� {startGold}Gold �����Ͽ����ϴ�");

        //......
    }


    private void ResetPlay()
    {
        //������ �ʱ�ȭ
        InitData();

        //.....
    }

}
