using UnityEngine;

public class BallController : MonoBehaviour
{    
    private IBallMover _ballMoveProvider;
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
        _ballMoveProvider = GetComponent<IBallMover>();
    }

    private void Update()
    {
        if (_inputProvider.CheckInput())
        {
            _ballMoveProvider.SwapMovingDirection();
        }
    }
}