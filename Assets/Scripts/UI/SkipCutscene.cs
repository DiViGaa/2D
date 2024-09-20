using UnityEngine;

public class SkipCutscene : MonoBehaviour
{
    [SerializeField] private CutsceneController _cutsceneController;

    public void Stop()
    {
        _cutsceneController.StopCutscene();
    }

    public void Skip()
    {
        _cutsceneController.LoadNextScene();
    }
}
