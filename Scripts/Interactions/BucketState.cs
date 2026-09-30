using UnityEngine;

public class BucketState : MonoBehaviour
{
    public GameObject waterVisual;

    public bool HasWater { get; private set; } = false;

    public void FillBucket()
    {
        HasWater = true;

        if (waterVisual != null)
            waterVisual.SetActive(true);

        Debug.Log("Bucket is now full.");
    }

    public void EmptyBucket()
    {
        HasWater = false;

        if (waterVisual != null)
            waterVisual.SetActive(false);

        Debug.Log("Bucket is now empty.");
    }
}