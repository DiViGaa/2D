using UnityEngine;

public class Parallax_2 : MonoBehaviour
{
    [SerializeField] private float parallaxEffect;
    [SerializeField] private GameObject _player;

    private float _startPos;
    private float lenght;

    private void Start()
    {
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
        _startPos = transform.position.x;
    }

    private void FixedUpdate()
    {
        float temp = _player.transform.position.x * (1 - parallaxEffect);
        float dist = _player.transform.position.x * parallaxEffect;

        transform.position = new Vector2(_startPos + dist, transform.position.y);
        if (temp > _startPos + lenght)
            _startPos += lenght;
        else if(temp < _startPos - lenght)
            _startPos -= lenght;
    }
}
