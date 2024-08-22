using UnityEngine;
using System.Collections.Generic;

public class ParticleCollisionHandler : MonoBehaviour
{
    [SerializeField] private GameObject splashPrefab;

    private void OnParticleCollision(GameObject other)
    {
        ParticleSystem particleSystem = GetComponent<ParticleSystem>();

        List<ParticleCollisionEvent> collisionEvents = new List<ParticleCollisionEvent>();

        int collisionCount = particleSystem.GetCollisionEvents(other, collisionEvents);

        for (int i = 0; i < collisionCount; i++)
        {
            Instantiate(splashPrefab, collisionEvents[i].intersection, Quaternion.identity);
        }
    }
}
