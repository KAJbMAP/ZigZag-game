using UnityEngine;
using System.Collections;

public abstract class BaseCrystal : MonoBehaviour
{
    private int revard;
    public int Revard { get => revard; private set => revard = value; }

    public virtual void Collect()
    {
        gameObject.SetActive(false);
    }
}
