using UnityEngine;

public class FireInteraction : MonoBehaviour
{
    [Header("Bucket")]
    public BucketState bucket;
    public float extinguishDistance = 2f;

    [Header("Fire")]
    public GameObject fireObject;

    [Header("After Fire")]
    public GameObject thankYouText;

    [Header("Guidance")]
    public BucketGuidanceManager guidanceManager;

    [Header("Ending")]
    public EndScreenController endScreenController;

    private bool fireExtinguished = false;

    public void ExtinguishFire()
    {
        if (fireExtinguished)
            return;

        if (bucket == null)
        {
            Debug.Log("Bucket reference is missing.");
            return;
        }

        // Bucket must contain water
        if (!bucket.HasWater)
        {
            Debug.Log("The bucket needs water.");
            return;
        }

        // Bucket must be close enough to the fire/man
        float distance = Vector3.Distance(
            bucket.transform.position,
            fireObject.transform.position
        );

        if (distance > extinguishDistance)
        {
            Debug.Log("Bring the bucket closer to the fire.");
            return;
        }

        // SUCCESS
        fireExtinguished = true;

        if (thankYouText != null)
            thankYouText.SetActive(true);

        // Empty the bucket after using the water
        bucket.EmptyBucket();

        // Turn off the fire
        if (fireObject != null)
            fireObject.SetActive(false);

        // Tell the guidance system this objective is complete
        if (guidanceManager != null)
            guidanceManager.FireExtinguished();

        if (endScreenController != null)
            endScreenController.ShowEndScreen();

        Debug.Log("Fire extinguished!");
    }
}