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
        //����� nowLevel �� ��������
        int nowLevel = PlayerPrefs.GetInt("NowLevel", 1);
        Debug.Log($"������ nowLevel: " + nowLevel);

        //levelButtons �迭 ����
        levelButtons = new Button[contents.childCount];

        //���� ��ư ���� - ���� ��/���
        for (int i = 0; i < levelButtons.Length; i++)
        {
            Transform child = contents.GetChild(i);
            levelButtons[i] = child.GetComponent<Button>();

            if (i >= nowLevel)
            {
                levelButtons[i].interactable = false;
            }
        }

        //���� �÷����� ������ �������� ���̸� ����
        float scrollHeight = scrollRect.rect.height;
        float contentsHeight = 110 + (int)((levelButtons.Length - 1) / 5) * (110 + 7);
        float dHeight = contentsHeight - scrollHeight;
        if(dHeight > 0)
        {
            //���� �÷����� ������ ���� ��ũ�� �� ����
            float nowLeveHeight = (int)((nowLevel - 1) / 5) * (110 + 7);
            scrollbar.value = 1 - nowLeveHeight / dHeight;
            if(scrollbar.value < 0)
                scrollbar.value = 0;
        }

    }


    //���� ���ý� ȣ��Ǵ� �Լ�
    public void LevelButtonSelect(string sceneName)
    {
        fader.FadeTo(sceneName);
    }

}


/*
//���ӵ����� ����/�ε� : ���� - ����̽��� ����/�ε�, ���� - �����ͺ��̽��� ����/�ε�
// PlayerPrefs 
PlayerPrefs.SetInt(string KeyName, int value); //KeyName ���� value ����
PlayerPrefs.GetInt(string KeyName);            //KeyName ���� ����� value ��������

PlayerPrefs.Setflaot(string KeyName, float value); //KeyName ���� value ����
PlayerPrefs.Getfloat(string KeyName);            //KeyName ���� ����� value ��������

PlayerPrefs.SetString(string KeyName, string value); //KeyName ���� value ����
PlayerPrefs.GetString(string KeyName);            //KeyName ���� ����� value ��������
*/
