using UnityEngine;

public class MouseInputController : MonoBehaviour, IInputController
{
    public int MouseButtonIndex = 0;

    public bool CheckInput()
    {
        return Input.GetMouseButtonDown(MouseButtonIndex);
    }
}