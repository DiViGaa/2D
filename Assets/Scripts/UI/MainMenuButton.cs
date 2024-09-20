using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    public void Continue()
    {
        SceneManager.LoadScene("MainScene");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void NewGameButton()
    {
        SceneManager.LoadScene("OP_1");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
