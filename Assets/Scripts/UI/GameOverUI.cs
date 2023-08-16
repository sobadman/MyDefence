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

    //Ȱ��ȭ �ɶ� ���� 1���� ȣ��
    private void OnEnable()
    {
        roundsText.text = PlayerStats.Rounds.ToString();
    }

    private void Update()
    {
        //roundsText.text = PlayerStats.Rounds.ToString();
    }

    //Retry ��ư�� �������� ȣ��
    public void Retry()
    {
        //���� �÷��� ������ �ʱ�ȭ
        //PlayDataInit();

        //���� ���� �ҷ�����
        fader.FadeTo(SceneManager.GetActiveScene().name);
    }

    //Menu ��ư�� �������� ȣ��
    public void Menu()
    {
        fader.FadeTo(loadToScene);
    }
}
