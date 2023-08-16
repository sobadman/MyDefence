using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    //페이더 이미지 ( Color(R,G,B,A) : R0~1, G0~1, B0~1, A0~1 => 0:0 ~ 1:255 )
    public Image img;

    //값(Value)을 커브값으로 환산대응
    public AnimationCurve curve;

    [SerializeField]
    private float fadeTime = 1f;



    // Start is called before the first frame update
    void Start()
    {
        //페이드인
        StartCoroutine(FadeIn());
    }

    //씬 시작시 1초동안 페이드인 효과 (알파값 이용) - 코룬틴
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

    //씬 이동
    public void FadeTo(string sceneName)
    {
        StartCoroutine (FadeOut(sceneName));
    }

    //씬 시작시 1초동안 페이드아웃 효과 후 씬 이동 (알파값 이용)
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
