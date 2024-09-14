using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("MainScene");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
