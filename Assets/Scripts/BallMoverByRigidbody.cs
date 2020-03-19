using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(SphereCollider))]
public class BallMoverByRigidbody : MonoBehaviour, IBallMover
{
    [SerializeField] private float movingSpeed = 1f;
    [SerializeField] private Vector3 movingUpVector = Vector3.forward;
    [SerializeField] private Vector3 movingRightVector = Vector3.right;

    private bool _moveToRight;
    private Rigidbody _rigidbody;
    private Vector3 currentVelocity;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        currentVelocity = movingRightVector * movingSpeed;
        SetRigidbodyVelocity(_rigidbody, currentVelocity);
    }

    private void FixedUpdate()
    {
        SetRigidbodyVelocity(_rigidbody, currentVelocity);
    }

    public void SwapMovingDirection()
    {
        if (_moveToRight)
            currentVelocity = movingRightVector * movingSpeed;
        else
            currentVelocity = movingUpVector * movingSpeed;

        _moveToRight = !_moveToRight;
    }

    public void SetRigidbodyVelocity(Rigidbody rigidBody, Vector3 velocity)
    {
        var newVelocity = velocity;
        newVelocity.y = rigidBody.velocity.y;
        rigidBody.velocity = newVelocity;
    }
}