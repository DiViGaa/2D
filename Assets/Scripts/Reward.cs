using System.Collections.Generic;
using UnityEngine;

public class Reward : MonoBehaviour
{
    [SerializeField] private List<GameObject> _rewards;
    [SerializeField] private float Forse = 200;
    [SerializeField] private GameObject _rewardParent;

    public void CreateReward()
    {
        var rewardPrefab = RandomReward();
        var rewardInstance = Instantiate(rewardPrefab, transform.position, Quaternion.identity, _rewardParent.transform);
        Rigidbody2D rb = rewardInstance.GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.up * Forse);
    }

    private GameObject RandomReward()
    {
        return _rewards[Random.Range(0, _rewards.Count)];
    }
}
