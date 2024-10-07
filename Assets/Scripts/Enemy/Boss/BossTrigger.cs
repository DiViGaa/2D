using UnityEngine;
using UnityEngine.Serialization;

public class BossTrigger : MonoBehaviour
{
    [SerializeField] private ChangeMusic _changeMusic;
    [SerializeField] private GameObject _boss;
    [SerializeField] private UI _ui;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _boss.SetActive(true);
            _ui.BossHealthBar(true);
            _changeMusic.ChangeVolume();
            _changeMusic.ChangeToBossTheme();
            Destroy(gameObject);
        }

    }
}
