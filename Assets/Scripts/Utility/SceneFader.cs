using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    //���̴� �̹��� ( Color(R,G,B,A) : R0~1, G0~1, B0~1, A0~1 => 0:0 ~ 1:255 )
    public Image img;

    //��(Value)�� Ŀ�갪���� ȯ�����
    public AnimationCurve curve;

    [SerializeField]
    private float fadeTime = 1f;



    // Start is called before the first frame update
    void Start()
    {
        //���̵���
        StartCoroutine(FadeIn());
    }

    //�� ���۽� 1�ʵ��� ���̵��� ȿ�� (���İ� �̿�) - �ڷ�ƾ
    IEnumerator FadeIn()
    {
        float t = 1f;

        while(t > 0)
        {
            t -= Time.deltaTime;
            float a = curve.Evaluate(t);
            img.color = new Color(0, 0, 0, a);            
            yield return 0;
        }

        GameManager.isReady = false;
    }

    //�� �̵�
    public void FadeTo(string sceneName)
    {
        StartCoroutine (FadeOut(sceneName));
    }

    //�� ���۽� 1�ʵ��� ���̵�ƿ� ȿ�� �� �� �̵� (���İ� �̿�)
    IEnumerator FadeOut(string sceneName)
    {
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime;
            float a = curve.Evaluate(t);
            img.color = new Color(0, 0, 0, a);
            yield return 0;
        }

        SceneManager.LoadScene(sceneName);
    }


}
