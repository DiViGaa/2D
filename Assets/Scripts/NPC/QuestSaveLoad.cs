using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestSaveLoad : MonoBehaviour
{
    public List<QuestData> quests;

    private ISaveSystem _saveSystem;
    private SaveData _myData;

    private void Start()
    {
        LoadQuest();
    }

    public void LoadQuest()
    {
        _saveSystem = new JsonSaveSystem();
        _myData = _saveSystem.Load();

        List<Quest> questDataList = _myData.quests;

        foreach (var questData in questDataList)
        {
            QuestData quest = quests.Find(e => e.id == questData.id);

            if (quest != null)
            {
                quest.state = questData.status;

                if (quest.state)
                {
                    Destroy(GetComponent<BoxCollider2D>());
                }
            }
        }
    }
}
