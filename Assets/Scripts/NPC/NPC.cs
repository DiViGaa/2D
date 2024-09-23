using UnityEngine;
using UnityEngine.UI;

public class NPC : IntaractableObjects
{
    [SerializeField] private float _distanceToCloseDialog = 5;
    [SerializeField] private Collectibles _collectibles;
    [SerializeField] private InputManager _inputManager;
    [SerializeField] private Sprite[] _dealoguePartOne;
    [SerializeField] private Sprite[] _dealoguePartTwo;
    [SerializeField] private QuestData _questData;
    [SerializeField] private NPCSound _npsSound;
    [SerializeField] private Image _image;
    [SerializeField] private UI _ui;

    public int _index = 0;

    private bool _partOneCompleted = false;
    private Transform _playerTransform;
    private bool _isTalking = false;

    private void Start()
    {
        _questData = GetComponent<QuestData>();
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        _collectibles = _playerTransform.GetComponent<Collectibles>();
        _npsSound = GetComponent<NPCSound>();
    }

    private void Update()
    {
        if (_isTalking)
        {
            CloseDialoge();
            ScrollDialog();
        }    
    }

    public override void Interact()
    {
        if (_isTalking) return;
        _ui.ShowDialog(true);
        CharacterIsBusy.characterIsBusy = true;
        _isTalking = true;
        _index = -1;

        if (_collectibles._diamond >= 1 && _partOneCompleted)
        {
            _image.sprite = _dealoguePartTwo[0];
        }
        else
        {
            _image.sprite = _dealoguePartOne[0];
        }
    }

    private void ScrollDialog()
    {
        if (_inputManager.EIsPressed() && _isTalking)
        {
            _index++;

            if (_collectibles._diamond < 1 || !_partOneCompleted)
            {
                if (_index < _dealoguePartOne.Length)
                {
                    _image.sprite = _dealoguePartOne[_index];
                }
                else
                {
                    _partOneCompleted = true;
                }
            }
            else if (_collectibles._diamond >= 1 && _partOneCompleted)
            {
                if (_index < _dealoguePartTwo.Length)
                {
                    _image.sprite = _dealoguePartTwo[_index];
                }
                else
                {
                    _questData.state = true;
                    GetComponent<Reward>().CreateReward();
                    Destroy(GetComponent<BoxCollider2D>());
                    CharacterIsBusy.characterIsBusy = false;
                    _collectibles.SetDiamond(_collectibles._diamond - 1);
                    _npsSound.PlayerRewardSound();
                    _ui.ShowDiamond(false);
                    _ui.ShowDialog(false);
                    _isTalking = false;
                }
            }
        }
    }

    private void CloseDialoge()
    {
        bool allPartOneDialogCompleted = _index >= _dealoguePartOne.Length;
        bool allPartTwoDialogCompleted = _index >= _dealoguePartTwo.Length;
        bool hasDiamond = _collectibles._diamond >= 1;
        bool playerTooFar = DistanceToPlayer() > _distanceToCloseDialog;

        if (playerTooFar || (allPartOneDialogCompleted && !hasDiamond) || (allPartTwoDialogCompleted && hasDiamond && _partOneCompleted))
        {
            _ui.ShowDialog(false);
            CharacterIsBusy.characterIsBusy = false;
            _isTalking = false;
        }
    }

    private float DistanceToPlayer()
    {
        return (gameObject.transform.position -  _playerTransform.position).sqrMagnitude;
    }
}
