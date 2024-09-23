using UnityEngine;

public class SaveAnimator : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PlaySaveAnimation()
    {
        animator.SetTrigger("Save");
    }
}
