using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform _player;
    private Vector3 _position;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {

        _position = _player.position - new Vector3(0,-4,0);
        _position.z = -10f;
        transform.position = Vector3.Lerp(transform.position,_position, Time.deltaTime);

    }
}
