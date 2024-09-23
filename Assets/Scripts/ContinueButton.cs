using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ContinueButton : MonoBehaviour
{
    private Button _continueButton;

    private void Start()
    {
        _continueButton = GetComponent<Button>();
    }

    void Update()
    {
        if (File.Exists(Application.persistentDataPath + "/Save.json"))
            _continueButton.interactable = true;

        else
            _continueButton.interactable = false;
    }
}
