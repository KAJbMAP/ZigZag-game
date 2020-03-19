using UnityEngine;
using System.Collections;

public class CrystalCollector : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        var crystal = other.GetComponent<BaseCrystal>();
        crystal?.Collect();
    }
}
