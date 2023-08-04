using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
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
        Debug.Log("Retry Play");

        //게임 플레이 데이터 초기화
        //PlayDataInit();
        //씬을 새로 불러오기
        SceneManager.LoadScene("PlayScene");
    }

    //Menu 버튼을 눌렀을때 호출
    public void Menu()
    {
        Debug.Log("Goto Menu");
    }
}
