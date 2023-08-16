using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageTest : MonoBehaviour
{
    //스킬사용가능 여부 
    //bool skillUseable = false;
    //private float countdown = 0f;

    private float coolTime = 5f;
    public Image buttonImage;

    private void Start()
    {
        //스킬 초기화
        InitSkill();
        StartCoroutine(ChargeSkill());
    }

    /*private void Update()
    {
        //SkillCharge();
    }

    void SkillCharge()
    {
        if (skillUseable == true)
            return;
        
        countdown += Time.deltaTime;
        if (countdown >= coolTime)
        {
            //스킬사용 가능하게 만든다
            skillUseable = true;
        }

        //버튼이미지            
        buttonImage.fillAmount = countdown / coolTime;        
    }

    //스킬 버튼 클릭시 호출 - update()에서 충전
    public void SkillUse()
    {
        if(skillUseable == false)
        {
            Debug.Log("스킬 사용 불가");
            return;
        }

        Debug.Log("스킬 사용");
        //스킬 기능 구현
        //......


        InitSkill();
    }*/

    //스킬 버튼 클릭시 호출 - 코루틴을 이용해서 충전
    public void UseSkill()
    {
        Debug.Log("스킬 사용");
        InitSkill();

        //5초 타이머 - 코루틴
        StartCoroutine(ChargeSkill());
    }

    IEnumerator ChargeSkill()
    {
        float t = 0f;

        while(t <= coolTime)
        {
            t += Time.deltaTime;
            buttonImage.fillAmount = t / coolTime;
            yield return 0;
        }

        buttonImage.GetComponent<Button>().interactable = true;
    }

    //스킬 관련 변수 값 초기화
    void InitSkill()
    {
        //skillUseable = false;
        //countdown = 0f;

        buttonImage.GetComponent<Button>().interactable = false;
    }
}
