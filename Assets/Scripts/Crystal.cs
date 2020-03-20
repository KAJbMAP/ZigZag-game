using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour, ICollectable
{
    [SerializeField] private int Revard;
    [SerializeField] private ParticleSystem DestroyParticles;
    [SerializeField] private GameObject CrystalObject;

    public int Collect()
    {
        DestroyParticles.Play();
        CrystalObject.SetActive(false);
        return Revard;
    }

    private void OnParticleSystemStopped()
    {
        gameObject.SetActive(false);
    }
}
