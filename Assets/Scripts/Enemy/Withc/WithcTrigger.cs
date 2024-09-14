using UnityEngine;

public class WithcTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _withc;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && collision != null)
            _withc.gameObject.SetActive(true);
            
    }
}
