using UnityEngine;

public class NPC : IntaractableObjects
{
    [SerializeField] private Sprite[] _dealogue;
    [SerializeField] private UI _ui;

    private void Update()
    {
        CheckDistance();
    }

    public override void Interact()
    {
        _ui.ShowDialog(true);
    }

    private float DistanceToPlayer()
    {
        return Vector2.Distance(gameObject.transform.position, GameObject.FindGameObjectWithTag("Player").transform.position);
    }

    private void CheckDistance()
    {
        if (DistanceToPlayer() > 5) 
        {
            _ui.ShowDialog(false);
        }
    }
}
