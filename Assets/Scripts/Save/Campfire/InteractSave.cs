using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractSave : IntaractableObjects
{
    [SerializeField] private EnemySaveLoad _enemySaveLoad;
    [SerializeField] private QuestSaveLoad _questSaveLoad;
    private ISaveSystem _saveSystem;
    private SaveData _myData;
    private PlayerParamaters _playerParam;
    private Collectibles _collectables;
    private Transform _cameraPos;
    private SaveAnimator _saveAnimator;

    private void Start()
    {
        _saveAnimator = GetComponent<SaveAnimator>();
        _saveSystem = new JsonSaveSystem();
        _playerParam = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerParamaters>();
        _collectables = GameObject.FindGameObjectWithTag("Player").GetComponent<Collectibles>();
        _cameraPos = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
        
    }

    public override void Interact()
    {
        _saveAnimator.PlaySaveAnimation();
        _myData = _saveSystem.Load();
        _myData.sceneName.sceneName = SceneManager.GetActiveScene().name;
        _myData.cameraPos.cameraPosition = _cameraPos.position;
        _myData.player.playerPosition = _playerParam.gameObject.transform.position;
        _myData.player.hp = _playerParam.HP;
        _myData.collectablesItem.armor = _collectables._armor;
        _myData.collectablesItem.healingBottle = _collectables._healingBottle;
        _myData.collectablesItem.coins = _collectables._coins;
        _myData.collectablesItem.diamond = _collectables._diamond;
        _myData.collectablesItem.theDiamondWasRaised = _collectables.theDiamondWasRaised;

        foreach (var enemyData in _enemySaveLoad.enemies)
        {
            var savedEnemyData = _myData.killedEnemies.Find(e => e.id == enemyData.id);
            savedEnemyData.alive = enemyData.isAlive;
        }

        foreach (var questData in _questSaveLoad.quests)
        {
            var savedQuestData = _myData.quests.Find(e => e.id == questData.id);
            savedQuestData.status = questData.state;
        }
        _saveSystem.Save(_myData);

    }
}
