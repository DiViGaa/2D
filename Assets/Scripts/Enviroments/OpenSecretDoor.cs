using UnityEngine;

public class OpenSecretDoor : AbstractCharacterParameters
{
    [SerializeField] private GameObject _secretDoor;

    public override void CheckHP()
    {
        if (HP <= 0)
            GetComponent<Animator>().SetTrigger("Open");
    }

    public override void TakeDamage(float damage)
    {
        HP -= damage;
        CheckHP();
    }

    public void OpenDoors()
    {
        Destroy(gameObject);
        _secretDoor.gameObject.SetActive(true);
    }
}
