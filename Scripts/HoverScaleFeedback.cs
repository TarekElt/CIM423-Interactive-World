using UnityEngine;

public class HoverScaleFeedback : MonoBehaviour
{
    public Transform target;
    public float hoverScaleMultiplier = 1.05f;

    private Vector3 originalScale;

    void Start()
    {
        if (target == null)
            target = transform;

        originalScale = target.localScale;
    }

    public void HoverEnter()
    {
        target.localScale =
            originalScale * hoverScaleMultiplier;
    }

    public void HoverExit()
    {
        target.localScale = originalScale;
    }
}