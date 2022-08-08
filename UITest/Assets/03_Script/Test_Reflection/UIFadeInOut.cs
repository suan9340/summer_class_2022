using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.Reflection;

public enum FadeState
{
    None,
    FadeOut,
    ChangeBg,
    FadeIn,
    Done,
}

public class UIFadeInOut : MonoBehaviour
{
    private FadeState fadeState;

    private Image imageBackground;

    IEnumerator iStateCoroutine = null;

    private const float ALPHA_LIMIT = 1.0f;
    private void Awake()
    {
        imageBackground = gameObject.GetComponent<Image>();
        if (imageBackground == null)
            Debug.LogWarning("이미지가 없어요!!");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && fadeState == FadeState.None)
        {
            Debug.Log("Space");
            fadeState = FadeState.None;
            NextState();
        }
    }

    private IEnumerator None()
    {
        Debug.Log("None");
        while (fadeState == FadeState.None)
        {
            fadeState = FadeState.FadeOut;
            yield return null;
        }

        NextState();
    }

    private IEnumerator FadeOut()
    {
        Debug.Log("FadeOut");
        var _alpha = 0f;

        while (fadeState == FadeState.FadeOut)
        {
            if (_alpha < ALPHA_LIMIT)
                _alpha += Time.deltaTime;
            else
                fadeState = FadeState.ChangeBg;

            _alpha = Mathf.Clamp(_alpha, 0, ALPHA_LIMIT);
            imageBackground.color = new Color(imageBackground.color.r, imageBackground.color.g, imageBackground.color.b, _alpha);

            yield return null;
        }

        NextState();
    }

    private IEnumerator ChangeBg()
    {
        yield return null;

        Debug.Log("ChangeBg");

        fadeState = FadeState.FadeIn;
        NextState();
    }

    private IEnumerator FadeIn()
    {
        Debug.Log("FadeIn");

        var _alpha = ALPHA_LIMIT;

        while (fadeState == FadeState.FadeIn)
        {
            if (_alpha > 0f)
                _alpha -= Time.deltaTime;
            else
                fadeState = FadeState.Done;

            _alpha = Mathf.Clamp(_alpha, 0f, ALPHA_LIMIT);

            imageBackground.color = new Color(imageBackground.color.r, imageBackground.color.g, imageBackground.color.b, _alpha);

            yield return null;
        }

        NextState();
    }

    private IEnumerator Done()
    {
        Debug.Log("Done");

        yield return null;
        fadeState = FadeState.None;
    }

    protected void NextState()
    {
        MethodInfo _mInfo = GetType().GetMethod(fadeState.ToString(), BindingFlags.Instance | BindingFlags.NonPublic);
        iStateCoroutine = (IEnumerator)_mInfo.Invoke(this, null);
        StartCoroutine(iStateCoroutine);
    }
}
