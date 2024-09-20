using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class CutsceneController : MonoBehaviour
{
    [SerializeField] private VideoPlayer _videoPlayer;
    [SerializeField] private string _nextSceneName;
    [SerializeField] private GameObject _panel;
    [SerializeField] private SceneLoaderAsync _sceneLoader;

    private bool _isCutscenePlaying = true;

    private void Start()
    {
        _videoPlayer.loopPointReached += OnVideoFinished;
        _sceneLoader.LoadNextSceneAsync(_nextSceneName);
    }

    private void Update()
    {
        if (_isCutscenePlaying && Input.GetKeyDown(KeyCode.Space) && _sceneLoader.SceneHasBeenLoaded())
        {
            _panel.SetActive(true);
        }
    }

    private void OnVideoFinished(VideoPlayer vp)
    {
        LoadNextScene();
    }

    public void LoadNextScene()
    {
        _isCutscenePlaying = false;
        _sceneLoader.ActivationScene();
    }

    public void StopCutscene()
    {
        _videoPlayer.Stop();
    }
}
