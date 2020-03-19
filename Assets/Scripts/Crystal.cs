using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : BaseCrystal
{
    public ParticleSystem DestroyParticles;

    public override void Collect()
    {
        DestroyParticles.Play();
    }

    private void OnParticleSystemStopped()
    {
        gameObject.SetActive(false);
    }
}
