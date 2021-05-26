using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum FadeState { FadeIn, FadeOut }

public class FadeInOut : MonoBehaviour
{
    [SerializeField]
    [Range(0.0f, 10f)]
    private float fadeTime;

    [SerializeField]
    private AnimationCurve fadeCurve;

    public Image black;
    private FadeState fadeState;

    // Start is called before the first frame update
    void Awake()
    {
    }

    private void Update()
    {

    }

    public void OnFade(FadeState state)
    {
        //Debug.Log("Fade started");

        fadeState = state;

        switch (fadeState)
        {
            case FadeState.FadeIn:
                StartCoroutine(Fade(1, 0));
                break;

            case FadeState.FadeOut:
                StartCoroutine(Fade(0, 1));
                break;
        }

    }

    public void FadeActiveorNot()
    {
        if (black.color.a < 0.001f)
        {
            gameObject.SetActive(false);
            Debug.Log(gameObject.activeInHierarchy);
        }
        else
            return;
    }

    private IEnumerator Fade(float start, float end)
    {
        //Debug.Log("Coroutine started");

        float currentTime = 0.0f;
        float percent = 0.0f;

        //Debug.Log(percent);

        while (percent < 1)
        {
            currentTime += Time.deltaTime;
            percent = currentTime / fadeTime;

            Color color = black.color;

            //Debug.Log(currentTime + "    " + percent);

            color.a = Mathf.Lerp(start, end, fadeCurve.Evaluate(percent));
            black.color = color;

            FadeActiveorNot();

            yield return null;
        }

    }
}
