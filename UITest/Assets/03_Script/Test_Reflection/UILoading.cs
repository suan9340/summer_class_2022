using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.Reflection;
using UnityEngine.SceneManagement;

public enum LoadingState
{
    None,
    UnLoad,
    GotoScene,
    Done,
}

public class UILoading : MonoBehaviour
{
    private AsyncOperation unLoadDone, loadLevelDone;
    private LoadingState loadingState;

    private StringBuilder sb;

    const float LOAD_LIMIT_TIME = 1.0f;

    private float currentLoadingTime;

    private void Awake()
    {
        sb = new StringBuilder();
    }

    private void Start()
    {
        loadingState = LoadingState.None;
        NextState();
    }

    private IEnumerator None()
    {
        loadingState = LoadingState.None;

        while (loadingState == LoadingState.None)
        {
            yield return null;
        }

        NextState();
    }

    private IEnumerator UnLoad()
    {
        unLoadDone = Resources.UnloadUnusedAssets();
        System.GC.Collect();

        while (loadingState == LoadingState.UnLoad)
        {
            if (unLoadDone.isDone)
            {
                loadingState = LoadingState.GotoScene;
            }

            yield return null;
        }

        NextState();
    }

    private IEnumerator GotoScene()
    {
        loadLevelDone = SceneManager.LoadSceneAsync("MainMenu");

        currentLoadingTime = LOAD_LIMIT_TIME;

        while (loadingState == LoadingState.GotoScene)
        {
            currentLoadingTime -= Time.deltaTime;
            if (loadLevelDone.isDone && currentLoadingTime <= 0)
            {
                loadingState = LoadingState.Done;
            }

            yield return null;
        }

        NextState();
    }

    private IEnumerator Done()
    {
        while (loadingState == LoadingState.Done)
        {
            yield return null;
        }
    }

    private void NextState()
    {
        sb.Remove(0, sb.Length);
        sb.Append(loadingState.ToString());
        sb.Append("State");

        MethodInfo _mInfo = GetType().GetMethod(sb.ToString(), BindingFlags.Instance | BindingFlags.NonPublic);
        StartCoroutine((IEnumerator)_mInfo.Invoke(this, null));
    }
}
