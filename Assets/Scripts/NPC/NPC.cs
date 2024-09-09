using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class NPC : IntaractableObjects
{
    [SerializeField] private Sprite[] _dealogueMain;
    [SerializeField] private Sprite[] _dealoguePartOne;
    [SerializeField] private Sprite[] _dealoguePartTwo;
    [SerializeField] private Collectibles _collectibles;
    [SerializeField] private Image _image;
    [SerializeField] private UI _ui;

    public int _index = -1;

    private Transform _playerTransform;

    private void Start()
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        CloseDialoge();
        ScrollDialog();
        CheckDiamond();
    }

    private void CheckDiamond()
    {
        if (_collectibles._diamond < 1)
            _dealogueMain = _dealoguePartOne;
        else
        {
            _dealogueMain = _dealoguePartTwo;
            if (_index == _dealogueMain.Length)
            {
                GetComponent<Reward>().CreateReward();
                _ui.ShowDiamond(false);
                _collectibles._diamond--;
                Destroy(GetComponent<BoxCollider2D>());
            }
        }

    }

    public override void Interact()
    {
        _ui.ShowDialog(true);
        InDialog.inDialog = true;
        _image.sprite = _dealogueMain[0];
    }

    private void ScrollDialog()
    {
        if (Input.GetKeyDown(KeyCode.E) && InDialog.inDialog) 
        {
            _index++;
            if (_index < _dealogueMain.Length)
            {
                _image.sprite = _dealogueMain[_index];
            }
        }
    }

    private void CloseDialoge()
    {
        if (DistanceToPlayer() > 5 || _dealogueMain.Length == _index) 
        {
            _ui.ShowDialog(false);
            InDialog.inDialog = false;
            _index = -1;
        }
    }
    private float DistanceToPlayer()
    {
        return Vector2.Distance(gameObject.transform.position, _playerTransform.position);
    }

}
