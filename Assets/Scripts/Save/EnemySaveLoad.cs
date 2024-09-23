using System.Collections.Generic;
using UnityEngine;

public class EnemySaveLoad : MonoBehaviour
{
    public List<Enemy> enemies;

    private ISaveSystem _saveSystem;
    private SaveData _myData;

    private void Start()
    {
        LoadEnemies();
    }

    public void LoadEnemies()
    {
        _saveSystem = new JsonSaveSystem();
        _myData = _saveSystem.Load();

        List<KilledEnemies> enemyDataList = _myData.killedEnemies;

        foreach (var enemyData in enemyDataList)
        {
            Enemy enemy = enemies.Find(e => e.id == enemyData.id);

            if (enemy != null)
            {
                enemy.isAlive = enemyData.alive;

                if (!enemy.isAlive)
                {
                    Destroy(enemy.gameObject);
                }
            }
        }
    }
}
