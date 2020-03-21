using UnityEngine;
using System.Collections;

public class TileMaterialController : MonoBehaviour
{    
    public Material TileMaterial;
    public Gradient GradientTileColor;
    public float ChangeColorSpeed = 1f;
    private float _gradientTimeValue = 0f;
    private void FixedUpdate()
    {      
        _gradientTimeValue = Mathf.Repeat(Time.time * ChangeColorSpeed, 1f);
        TileMaterial.SetColor("_BaseColor", GradientTileColor.Evaluate(_gradientTimeValue));
    }
}
