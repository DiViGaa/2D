using UnityEngine;

public class Wait : StateMachineBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _distanceToChase = 3f;
    [SerializeField] private float _waitTime = 5f;

    private float _timer;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _timer = 0f;
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector2.Distance(animator.transform.position, _player.position) <= _distanceToChase)
        {
            animator.SetBool("MoveOrChase",true);
            animator.SetBool("Wait", false);
        }
        _timer += Time.deltaTime;
        if (_timer > _waitTime)
        {
            animator.SetBool("Wait", false);
            animator.SetBool("MoveOrChase", true);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }


}
