using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;

public class SceneLoaderAsync : MonoBehaviour
{
    [SerializeField] OpUi _opUi;
    public AsyncOperation asyncLoad {  get; private set; }

    public void LoadNextSceneAsync(string nextSceneName)
    {
        StartCoroutine(LoadSceneAsync(nextSceneName));
    }

    private IEnumerator LoadSceneAsync(string nextSceneName)
    {
        asyncLoad = SceneManager.LoadSceneAsync(nextSceneName);
        asyncLoad.allowSceneActivation = false;

        while (SceneHasBeenLoaded())
        {
            yield return null;
        }
        _opUi.ShowSkipButton();
    }

    public bool SceneHasBeenLoaded()
    {
        return asyncLoad.progress >= 0.9f;
    }

    public void ActivationScene()
    {
        asyncLoad.allowSceneActivation = true;
    }
}
