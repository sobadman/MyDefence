using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public SceneFader fader;
    [SerializeField]
    private string loadToScene = "PlayScene";

    public void Play()
    {
        fader.FadeTo(loadToScene);
        //SceneManager.LoadScene(loadToScene);
        //SceneManager.LoadScene(1);
    }

    //���� ����
    public void Quit()
    {
        //���� ������ �ʱ�ȭ ġƮŰ
        PlayerPrefs.DeleteAll();

        Debug.Log("Game Quit");
        //�����Ϳ��� ������ �ȵǰ�, ���� ����̽����� ����˴ϴ�
        Application.Quit();
    }
}
