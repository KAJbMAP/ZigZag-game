using UnityEngine;

public class CameraTargetFollow : MonoBehaviour
{
    public Transform Target;
    public float Distance = 5f;

    private void LateUpdate()
    {
        transform.position = Target.position;
        transform.Translate(-transform.forward * Distance, Space.World);
    }
}