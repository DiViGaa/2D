using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SaveData
{
    public SceneName sceneName;
    public CollectablesItem collectablesItem;
    public Player player;
    public CameraPos cameraPos;
    public List<Quest> quests;
    public List<KilledEnemies> killedEnemies;
}

[Serializable]
public class Quest
{
    public int id;
    public bool status;
}

[Serializable]
public class KilledEnemies
{
    public int id;
    public bool alive;
}

[Serializable]
public class CollectablesItem
{
    public int healingBottle;
    public int armor;
    public int coins;
    public int diamond;
    public bool theDiamondWasRaised;
}

[Serializable]
public class Player
{
    public Vector2 playerPosition;
    public float hp;
}

[Serializable]
public class CameraPos
{
    public Vector2 cameraPosition;
}

[Serializable]
public class SceneName
{
    public string sceneName;
}
