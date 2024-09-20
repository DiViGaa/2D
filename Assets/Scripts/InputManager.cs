using UnityEngine;

public class InputManager : MonoBehaviour
{
    public bool EscapeIsPressed()
    {
        return Input.GetKeyDown(KeyCode.Escape);
    }

    public float HorizontalAxis()
    {
        return Input.GetAxis("Horizontal");
    }

    public float VerticalAxis()
    {
        return Input.GetAxis("Vertical");
    }

    public bool LShiftIsPressed()
    {
        return Input.GetKeyDown(KeyCode.LeftShift);
    }

    public bool SpaceIsPressed()
    {
        return Input.GetButtonDown("Jump");
    }

    public bool AttackButtonIsPressed()
    {
        return Input.GetButtonDown("Fire1");
    }

    public bool EIsPressed()
    {
        return Input.GetKeyDown(KeyCode.E);
    }
}
