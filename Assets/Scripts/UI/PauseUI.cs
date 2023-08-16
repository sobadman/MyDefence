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

        //PauseUI 게임오브젝트 활성화,비활성화
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Toggle();
        }
    }

    void Toggle()
    {        
        pauseUI.SetActive(!pauseUI.activeSelf);

        if (pauseUI.activeSelf == true) //창이 열렸을때
        {
            Time.timeScale = 0f;
        }
        else //창이 닫힐때
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
        //페이드 아웃하고 로드씬
        fader.FadeTo(loadToScene);
        Time.timeScale = 1f;
    }

}
