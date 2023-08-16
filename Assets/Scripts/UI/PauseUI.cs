using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{
    //Fader
    public SceneFader fader;
    [SerializeField]
    private string loadToScene = "MainMenu";

    //PauseUI
    public GameObject pauseUI;

    private void Update()
    {
        if (GameManager.IsGameOver || GameManager.isReady)
            return;

        //PauseUI ���ӿ�����Ʈ Ȱ��ȭ,��Ȱ��ȭ
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Toggle();
        }
    }

    void Toggle()
    {        
        pauseUI.SetActive(!pauseUI.activeSelf);

        if (pauseUI.activeSelf == true) //â�� ��������
        {
            Time.timeScale = 0f;
        }
        else //â�� ������
        {
            Time.timeScale = 1f;
        }
    }

    public void Continue()
    {
        Toggle();
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        fader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        //���̵� �ƿ��ϰ� �ε��
        fader.FadeTo(loadToScene);
        Time.timeScale = 1f;
    }

}
