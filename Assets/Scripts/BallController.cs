using UnityEngine;

public class BallController : MonoBehaviour
{    
    private IBallMover ballMoveProvider;
    private IInputController _inputProvider;

    private void Awake()
    {
#if UNITY_EDITOR
        _inputProvider = gameObject.AddComponent<MouseInputController>();
#elif UNITY_STANDALONE
        _inputProvider = gameObject.AddComponent<MouseInputController>();
#elif UNITY_ANDROID
        _inputProvider = gameObject.AddComponent<TouchInputController>();
#endif
        ballMoveProvider = GetComponent<IBallMover>();
    }

    private void Update()
    {
        if (_inputProvider.CheckInput())
        {
            ballMoveProvider.SwapMovingDirection();
        }
    }
}