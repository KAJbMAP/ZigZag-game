using UnityEngine;
using UnityEngine.Events;

public class CrystalCollector : MonoBehaviour
{
    public event UnityAction<int> CrystalCollected;

    private void OnTriggerEnter(Collider other)
    {
        var crystal = other.GetComponent<ICollectable>();
        if (crystal != null)
        {
            var revard = crystal.Collect();
            CrystalCollected?.Invoke(revard);
        }
    }
}
