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

    //게임 종료
    public void Quit()
    {
        //저장 데이터 초기화 치트키
        PlayerPrefs.DeleteAll();

        Debug.Log("Game Quit");
        //에디터에서 실행이 안되고, 실제 디바이스에서 실행됩니다
        Application.Quit();
    }
}
