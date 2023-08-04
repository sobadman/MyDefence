using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{
    //PauseUI
    public GameObject pauseUI;

    private void Update()
    {
        //PauseUI 게임오브젝트 활성화,비활성화
        if(Input.GetKeyDown(KeyCode.Escape))
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
        Debug.Log("Retry Play!!!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void Menu()
    {
        Debug.Log("Goto Menu!!!");
    }

}
