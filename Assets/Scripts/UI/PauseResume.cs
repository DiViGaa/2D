using UnityEngine;

public class PauseResume : MonoBehaviour
{
    [SerializeField] private UI _gameUI;
    [SerializeField] private InputManager _inputManager;

    private bool inPause;

    private void Update()
    {
        if (_inputManager.EscapeIsPressed() && !GameOver.gameOver && !CharacterIsBusy.characterIsBusy)
        {
            if (inPause)
            {
                PauseResumeGame(false, CursorLockMode.Locked, false, 1f);
            }
            else
            {
                PauseResumeGame(true, CursorLockMode.Confined, true, 0f);
            }
        }
    }

    private void PauseResumeGame(bool cursorVisible, CursorLockMode cursorMode, bool panelVisibility, float timeScale)
    {
        CursorState(cursorVisible, cursorMode);
        _gameUI.PausePanel(panelVisibility);
        TimeScale(timeScale);
    }

    public static void TimeScale(float timeScale)
    {
        Time.timeScale = timeScale;
    }

    public static void CursorState(bool cursorVisible, CursorLockMode cursorMode)
    {
        Cursor.visible = cursorVisible;
        Cursor.lockState = cursorMode;
    }

    public void RusumeWithButton()
    {
        PauseResumeGame(false, CursorLockMode.Locked, false, 1f);
    }
}
