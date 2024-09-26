using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform _player;
    private Vector3 _position;
    private ISaveSystem _saveSystem;
    private SaveData _myData;
    [SerializeField] private float _cameraSpeed = 5f;

    private void Start()
    {
        _saveSystem = new JsonSaveSystem();
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        Init();
        
    }
    
    private void Update()
    {
        _position = _player.position - new Vector3(0,-4,0);
        _position.z = -10f;
        transform.position = Vector3.Lerp(transform.position,_position,_cameraSpeed * Time.deltaTime);

    }

    private void Init()
    {
        _myData = _saveSystem.Load();
        transform.position = _myData.cameraPos.cameraPosition;
    }
}
