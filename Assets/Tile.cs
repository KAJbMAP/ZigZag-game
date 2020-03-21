using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private string HideAnimationTriggerName;

    public void Hide()
    {
        animator?.SetTrigger(HideAnimationTriggerName);
    }

    private void OnAnimationEnd()
    {
        Destroy(gameObject);
    }

}
