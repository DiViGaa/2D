using UnityEngine;

public class SaveEffect : MonoBehaviour
{
    private ParticleSystem _particleSystem;

    private void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
    }

    public void PlayParticles()
    {
        if (_particleSystem != null)
        {
            _particleSystem.Play();
        }
    }
}
