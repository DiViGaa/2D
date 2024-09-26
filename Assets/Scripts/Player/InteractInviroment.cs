using UnityEngine;

public class InteractInviroment : MonoBehaviour
{
    [SerializeField] private LayerMask _interactableLayer;
    [SerializeField] private InputManager _inputManager;
    [SerializeField] private float _interactRange = 5f;
    [SerializeField] private UI _ui;

    void Update()
    {
        Interact();
    }
    
    private void Interact()
    {
        Collider2D[] interactableObjects = Physics2D.OverlapCircleAll(transform.position, _interactRange, _interactableLayer);

        if (interactableObjects.Length > 0 && !CharacterIsBusy.characterIsBusy)
            _ui.InteractLabel(true);

        else
            _ui.InteractLabel(false);

        if (_inputManager.EIsPressed() && !CharacterIsBusy.characterIsBusy)
        {
            foreach (var objects in interactableObjects)
            {
                objects.GetComponent<IntaractableObjects>().Interact();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _interactRange);
    }
}
