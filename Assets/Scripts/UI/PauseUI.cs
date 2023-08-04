using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{
    //PauseUI
    public GameObject pauseUI;

    private void Update()
    {
        //PauseUI ���ӿ�����Ʈ Ȱ��ȭ,��Ȱ��ȭ
        if(Input.GetKeyDown(KeyCode.Escape))
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
        Debug.Log("Retry Play!!!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void Menu()
    {
        Debug.Log("Goto Menu!!!");
    }

}
