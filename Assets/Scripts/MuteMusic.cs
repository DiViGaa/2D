using UnityEngine;

public class MuteMusic : MonoBehaviour
{
    [SerializeField] private AudioSource _mainMusic;
    [SerializeField] private AudioSource _enviromentsSound;

    public void Mute()
    {
        _mainMusic.mute = true;
        _enviromentsSound.mute = true;
    }
}
