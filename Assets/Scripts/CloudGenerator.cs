using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudGenerator : MonoBehaviour
{
    [SerializeField] private List<GameObject> _sprites = new List<GameObject>();
    [SerializeField] private List<GameObject> _createdSprites = new List<GameObject>();
    [SerializeField] private int _maxClouds = 5;
    [SerializeField] private float _cloudSpeed = 2f;

    private GameObject _randomCloud;
    private void Start()
    {
        StartCoroutine(SpawnCloud());
    }

    void Update()
    {
        RemoveUnnecessaryClouds();
        MoveCloud();
    }

    private IEnumerator SpawnCloud()
    {
        while (true || _maxClouds < _createdSprites.Count)
        {
            RandomCloud();
            _createdSprites.Add(Instantiate(_randomCloud, transform.position, Quaternion.identity ,transform.parent));
            yield return new WaitForSeconds(3);   
        }
    }

    private void RandomCloud()
    {
        _randomCloud = _sprites[Random.Range(0, _sprites.Count)];

    }

    private void RemoveUnnecessaryClouds()
    {
        if (Vector2.Distance(_createdSprites[0].transform.position,gameObject.transform.position) > 30)
        {
            Destroy(_createdSprites[0]);
            _createdSprites.RemoveAt(0);
        }
    }

    private void MoveCloud()
    {
        foreach (var cloud in _createdSprites)
        {
            cloud.transform.Translate(Vector3.left * _cloudSpeed * Time.deltaTime);
        }
    }
}
