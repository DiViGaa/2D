using UnityEngine;
using UnityEngine.UI;

public class OpUi : MonoBehaviour
{
    [SerializeField] private SceneLoaderAsync _sceneLoader;
    [SerializeField] private GameObject _skipButton;

    public void ShowSkipButton()
    {
        _skipButton.SetActive(true);
    }
}
