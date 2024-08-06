using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _player;
    private Vector3 _position;

    private void Update()
    {

        _position = _player.position;
        _position.z = -10f;
        transform.position = Vector3.Lerp(transform.position,_position, Time.deltaTime);

    }
}
