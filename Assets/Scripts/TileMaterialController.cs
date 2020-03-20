using UnityEngine;
using System.Collections;

public class TileMaterialController : MonoBehaviour
{
    public Transform Ball;
    public Material TileMaterial, CrystalMaterial;
    public Gradient GradientTileColor;
    public float ChangeColorSpeed = 1f;
    private float _gradientTimeValue = 0f;
    private Vector3 _ballCoordinate = Vector3.zero;
    private void FixedUpdate()
    {
        _ballCoordinate = Ball.position;
        _ballCoordinate.y = 0f;
        TileMaterial.SetVector("_TargetPosition", _ballCoordinate);
        CrystalMaterial.SetVector("_TargetPosition", _ballCoordinate);

        _gradientTimeValue = Mathf.Repeat(Time.time * ChangeColorSpeed, 1f);
        TileMaterial.SetColor("_Albedo", GradientTileColor.Evaluate(_gradientTimeValue));
    }

    private void OnDisable()
    {
        TileMaterial.SetVector("_TargetPosition", Vector3.zero);
        CrystalMaterial.SetVector("_TargetPosition", _ballCoordinate);
    }
}
