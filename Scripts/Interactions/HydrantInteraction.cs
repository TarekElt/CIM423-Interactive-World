using UnityEngine;

public class HydrantInteraction : MonoBehaviour
{
    [Header("Bucket")]
    public BucketState bucket;

    [Header("Guidance")]
    public BucketGuidanceManager guidanceManager;

    [Header("Fill Settings")]
    public float fillDistance = 2f;

    public void UseHydrant()
    {
        if (bucket == null)
        {
            Debug.Log("Bucket reference is missing.");
            return;
        }

        float distance = Vector3.Distance(
            bucket.transform.position,
            transform.position
        );

        if (distance <= fillDistance)
        {
            // Fill the bucket
            bucket.FillBucket();

            // Advance the guidance system
            if (guidanceManager != null)
            {
                guidanceManager.BucketFilled();
            }

            Debug.Log("Hydrant filled the bucket.");
        }
        else
        {
            Debug.Log("Bring the bucket closer to the hydrant.");
        }
    }
}