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

    //애니키 보여주기 체크
    private bool isShowAnyKey = false;
    //코루틴 호출 체크
    private bool isCorutine = false;

    public GameObject anyKeyUI;

    private void Start()
    {
        //3초 지연 코루틴 구현
        //StartCoroutine(ShowAnyKey());

        //3초 지연 Invoke 구현
        Invoke("ShowPressAnyKey", 3f);
    }

    private void Update()
    {
        //3초 타이머 구현        
        /*if (isShowAnyKey == false)
        {
            keyCountdown += Time.deltaTime;
            if (keyCountdown >= anyKeyTime)
            {
                //애니키 텍스트 보여주기
                anyKeyUI.SetActive(true);
                isShowAnyKey = true;
            }
        }*/

        //3초 지연 코루틴 구현
        if(isCorutine == false)
        {
            StartCoroutine(ShowAnyKey());
            isCorutine = true;
        }


        //10초 타이머 구현
        countdown += Time.deltaTime;
        if(countdown >= delayTime)
        {
            //메뉴이동
            GotoMenu();
            return;
        }

        //애니키 누르면
        if (Input.anyKeyDown && isShowAnyKey == true)
        {
            //메뉴이동
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
