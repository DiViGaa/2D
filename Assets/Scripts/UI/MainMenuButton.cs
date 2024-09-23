using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    private ISaveSystem _saveSystem;
    private SaveData _myData;

    private void Start()
    {
        _saveSystem = new JsonSaveSystem();
    }

    public void StartNewGame()
    {
        CreateStartData();
        _saveSystem.Save(_myData);

        SceneManager.LoadScene(_myData.sceneName.sceneName);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void ContinueGame()
    {
        if (File.Exists(Application.persistentDataPath + "/Save.json"))
        {
            _myData = _saveSystem.Load();
            SceneManager.LoadScene(_myData.sceneName.sceneName);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
    public void ExitButton()
    {
        Application.Quit();
    }

    private void CreateStartData()
    {
        _myData = new SaveData()
        {
            player = new Player()
            {
                hp = 100,
                playerPosition = new Vector3(-8.75f, -0.449999988f, 0)
            },
            collectablesItem = new CollectablesItem()
            {
                armor = 0,
                healingBottle = 0,
                diamond = 0,
                coins = 0,
                theDiamondWasRaised = false
            },
            cameraPos = new CameraPos()
            {
                cameraPosition = new Vector3(-8.72000027f, 2.97000003f, -10)
            },
            quests = new List<Quest>()
            {
                new Quest()
                {
                    id = 1,
                    status = false
                }
            },
            killedEnemies = new List<KilledEnemies>()
            {
                new KilledEnemies()
                {
                    id = 1,
                    alive = true
                },
                new KilledEnemies()
                {
                    id = 2,
                    alive = true
                }
            },
            sceneName = new SceneName()
            {
                sceneName = "OP_1"
            }
        };
    }
}
