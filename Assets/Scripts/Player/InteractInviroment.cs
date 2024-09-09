using UnityEngine;

public class InteractInviroment : MonoBehaviour
{
    [SerializeField] private float _interactRange = 5f;
    [SerializeField] private LayerMask _interactableLayer;

    void Update()
    {
        Interact();
    }

    private void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E) && !InDialog.inDialog)
        {
            Collider2D[] interactableObjects = Physics2D.OverlapCircleAll(transform.position, _interactRange, _interactableLayer);
            foreach (var objects in interactableObjects)
            {
                objects.GetComponent<IntaractableObjects>().Interact();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _interactRange);
    }
}
