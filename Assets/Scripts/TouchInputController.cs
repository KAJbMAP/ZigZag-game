using UnityEngine;

public class TouchInputController : MonoBehaviour, IInputController
{
    public bool CheckInput()
    {
        return Input.GetTouch(0).phase == TouchPhase.Began;
    }
}