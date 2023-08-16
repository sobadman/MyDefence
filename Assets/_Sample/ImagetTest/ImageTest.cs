using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageTest : MonoBehaviour
{
    //��ų��밡�� ���� 
    //bool skillUseable = false;
    //private float countdown = 0f;

    private float coolTime = 5f;
    public Image buttonImage;

    private void Start()
    {
        //��ų �ʱ�ȭ
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
            //��ų��� �����ϰ� �����
            skillUseable = true;
        }

        //��ư�̹���            
        buttonImage.fillAmount = countdown / coolTime;        
    }

    //��ų ��ư Ŭ���� ȣ�� - update()���� ����
    public void SkillUse()
    {
        if(skillUseable == false)
        {
            Debug.Log("��ų ��� �Ұ�");
            return;
        }

        Debug.Log("��ų ���");
        //��ų ��� ����
        //......


        InitSkill();
    }*/

    //��ų ��ư Ŭ���� ȣ�� - �ڷ�ƾ�� �̿��ؼ� ����
    public void UseSkill()
    {
        Debug.Log("��ų ���");
        InitSkill();

        //5�� Ÿ�̸� - �ڷ�ƾ
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

    //��ų ���� ���� �� �ʱ�ȭ
    void InitSkill()
    {
        //skillUseable = false;
        //countdown = 0f;

        buttonImage.GetComponent<Button>().interactable = false;
    }
}
