using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    public SceneFader fader;

    public Transform contents;
    private Button[] levelButtons;

    public RectTransform scrollRect;
    public RectTransform contentsRect;
    public Scrollbar scrollbar;

    private void Start()
    {
        //저장된 nowLevel 값 가져오기
        int nowLevel = PlayerPrefs.GetInt("NowLevel", 1);
        Debug.Log($"가져온 nowLevel: " + nowLevel);

        //levelButtons 배열 선언
        levelButtons = new Button[contents.childCount];

        //레벨 버튼 셋팅 - 레벨 락/언락
        for (int i = 0; i < levelButtons.Length; i++)
        {
            Transform child = contents.GetChild(i);
            levelButtons[i] = child.GetComponent<Button>();

            if (i >= nowLevel)
            {
                levelButtons[i].interactable = false;
            }
        }

        //현재 플레이할 레벨로 컨텐츠의 높이를 조정
        float scrollHeight = scrollRect.rect.height;
        float contentsHeight = 110 + (int)((levelButtons.Length - 1) / 5) * (110 + 7);
        float dHeight = contentsHeight - scrollHeight;
        if(dHeight > 0)
        {
            //현재 플레이할 레벨에 따른 스크롤 할 높이
            float nowLeveHeight = (int)((nowLevel - 1) / 5) * (110 + 7);
            scrollbar.value = 1 - nowLeveHeight / dHeight;
            if(scrollbar.value < 0)
                scrollbar.value = 0;
        }

    }


    //레벨 선택시 호출되는 함수
    public void LevelButtonSelect(string sceneName)
    {
        fader.FadeTo(sceneName);
    }

}


/*
//게임데이터 저장/로드 : 파일 - 디바이스에 저장/로드, 서버 - 데이터베이스에 저장/로드
// PlayerPrefs 
PlayerPrefs.SetInt(string KeyName, int value); //KeyName 으로 value 저장
PlayerPrefs.GetInt(string KeyName);            //KeyName 으로 저장된 value 가져오기

PlayerPrefs.Setflaot(string KeyName, float value); //KeyName 으로 value 저장
PlayerPrefs.Getfloat(string KeyName);            //KeyName 으로 저장된 value 가져오기

PlayerPrefs.SetString(string KeyName, string value); //KeyName 으로 value 저장
PlayerPrefs.GetString(string KeyName);            //KeyName 으로 저장된 value 가져오기
*/
