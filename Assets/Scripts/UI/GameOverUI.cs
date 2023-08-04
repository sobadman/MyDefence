using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
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
        Debug.Log("Retry Play");

        //���� �÷��� ������ �ʱ�ȭ
        //PlayDataInit();
        //���� ���� �ҷ�����
        SceneManager.LoadScene("PlayScene");
    }

    //Menu ��ư�� �������� ȣ��
    public void Menu()
    {
        Debug.Log("Goto Menu");
    }
}
