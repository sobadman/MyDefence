using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MoneyTest : MonoBehaviour
{
    //소지금
    private int gold;

    [SerializeField]
    private int startGold = 100000;

    //소지금 UI
    public TextMeshProUGUI goldText;

    //1000, 9000 버튼
    public Button button1000;
    public Button button9000;

    private void Start()
    {
        //초기화
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


        //소지금 UI 연결
        goldText.text = gold.ToString() + " Gold";
    }


    //돈을 버는것 : 사냥, 퀘스트, 캐쉬 구매
    public void AddMoney(int amount)
    {
        gold += amount;
    }

    //돈을 쓰는것 : 아이템 구매, 콘텐츠 사용 비용
    //소지금이 부족할때 - 구매실패, fasle 반환 
    //소지금이 충분할때 - 구매성공, true 반환
    public bool UseMoney(int amount)
    {
        //소지금 체크
        if(gold < amount)
        {
            Debug.Log("돈이 부족 합니다");
            return false;
        }

        gold -= amount;
        return true;
    }

    //소지금 잔고 확인
    public bool HasMoney(int amount)
    {
        if(gold < amount)
        {
            return false;
        }

        return true;
    }


    //1000원 저축
    public void Save1000()
    {
        Debug.Log("1000원을 저축 했습니다");
        AddMoney(1000);
    }

    //1000원 구매 - hp 포션 구매
    public void Purchase1000()
    {
        if (UseMoney(1000) == true)
        {
            //구매 내역 구현
            Debug.Log($"포션 아이템을 구매 했습니다");
        }
    }

    //9000원 구매 - 단검 구매
    public void Purchase9000()
    {
        if (UseMoney(9000) == true)
        {
            //구매 내역 구현
            Debug.Log($"단검 아이템을 구매 했습니다");
        }
    }

    //데이터 초기화 함수
    void InitData()
    {
        gold = startGold;
        Debug.Log($"소지금을 {startGold}Gold 지급하였습니다");

        //......
    }


    private void ResetPlay()
    {
        //데이터 초기화
        InitData();

        //.....
    }

}
