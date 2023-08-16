using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    //Fader
    public SceneFader fader;
    [SerializeField]
    private string loadToScene = "MainMenu";

    public TextMeshProUGUI roundsText;

    //활성화 될때 마다 1번만 호출
    private void OnEnable()
    {
        roundsText.text = PlayerStats.Rounds.ToString();
    }

    private void Update()
    {
        //roundsText.text = PlayerStats.Rounds.ToString();
    }

    //Retry 버튼을 눌렀을때 호출
    public void Retry()
    {
        //게임 플레이 데이터 초기화
        //PlayDataInit();

        //씬을 새로 불러오기
        fader.FadeTo(SceneManager.GetActiveScene().name);
    }

    //Menu 버튼을 눌렀을때 호출
    public void Menu()
    {
        fader.FadeTo(loadToScene);
    }
}
