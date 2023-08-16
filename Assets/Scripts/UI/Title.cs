using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public SceneFader fader;
    [SerializeField]
    private string loadToScene = "MainMenu";

    [SerializeField]
    private float delayTime = 10f;
    private float countdown = 0;

    [SerializeField]
    private float anyKeyTime = 3f;
    private float keyCountdown = 0f;

    //�ִ�Ű �����ֱ� üũ
    private bool isShowAnyKey = false;
    //�ڷ�ƾ ȣ�� üũ
    private bool isCorutine = false;

    public GameObject anyKeyUI;

    private void Start()
    {
        //3�� ���� �ڷ�ƾ ����
        //StartCoroutine(ShowAnyKey());

        //3�� ���� Invoke ����
        Invoke("ShowPressAnyKey", 3f);
    }

    private void Update()
    {
        //3�� Ÿ�̸� ����        
        /*if (isShowAnyKey == false)
        {
            keyCountdown += Time.deltaTime;
            if (keyCountdown >= anyKeyTime)
            {
                //�ִ�Ű �ؽ�Ʈ �����ֱ�
                anyKeyUI.SetActive(true);
                isShowAnyKey = true;
            }
        }*/

        //3�� ���� �ڷ�ƾ ����
        if(isCorutine == false)
        {
            StartCoroutine(ShowAnyKey());
            isCorutine = true;
        }


        //10�� Ÿ�̸� ����
        countdown += Time.deltaTime;
        if(countdown >= delayTime)
        {
            //�޴��̵�
            GotoMenu();
            return;
        }

        //�ִ�Ű ������
        if (Input.anyKeyDown && isShowAnyKey == true)
        {
            //�޴��̵�
            GotoMenu();
        }
    }

    void GotoMenu()
    {
        fader.FadeTo(loadToScene);
    }

    IEnumerator ShowAnyKey()
    {
        yield return new WaitForSeconds(anyKeyTime);
        anyKeyUI.SetActive(true);
        isShowAnyKey = true;
    }

    void ShowPressAnyKey()
    {
        anyKeyUI.SetActive(true);
        isShowAnyKey = true;
    }


}
