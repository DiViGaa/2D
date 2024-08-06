using UnityEngine;

public class Parallax_2 : MonoBehaviour
{
    [SerializeField] private GameObject _camera;
    [SerializeField] private float parallaxEffect;

    private float lenght, _startPos;

    private void Start()
    {
        _startPos = transform.position.x;
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void FixedUpdate()
    {
        float temp = _camera.transform.position.x * (1 - parallaxEffect);
        float dist = _camera.transform.position.x * parallaxEffect;

        transform.position = new Vector2(_startPos + dist, transform.position.y);
        if (temp > _startPos + lenght)
            _startPos += lenght;
        else if(temp < _startPos - lenght)
            _startPos -= lenght;
    }
}