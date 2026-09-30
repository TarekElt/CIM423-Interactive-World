using UnityEngine;

public class BucketGuidanceManager : MonoBehaviour
{
    public enum GuidanceStage
    {
        FindBucket,
        GoToHydrant,
        FillBucket,
        GoToMan,
        ExtinguishFire,
        Complete
    }

    [Header("Objects")]
    public Transform bucket;
    public Transform fireHydrant;
    public Transform burningMan;

    [Header("Beacons")]
    public GameObject bucketBeacon;
    public GameObject hydrantBeacon;
    public GameObject manBeacon;

    [Header("Ranges")]
    public float hydrantRange = 2f;
    public float manRange = 3f;

    [Header("Current State")]
    public GuidanceStage stage = GuidanceStage.FindBucket;

    private bool bucketHeld = false;
    private bool reachedHydrant = false;
    private bool reachedMan = false;

    void Start()
    {
        UpdateBeacons();
    }

    void Update()
    {
        CheckTargetRanges();
    }

    private void CheckTargetRanges()
    {
        // EMPTY BUCKET → HYDRANT
        if (stage == GuidanceStage.GoToHydrant && !reachedHydrant)
        {
            float distance = Vector3.Distance(
                bucket.position,
                fireHydrant.position
            );

            if (distance <= hydrantRange)
            {
                reachedHydrant = true;
                stage = GuidanceStage.FillBucket;

                Debug.Log("Hydrant range reached.");

                UpdateBeacons();
            }
        }

        // FULL BUCKET → MAN
        if (stage == GuidanceStage.GoToMan && !reachedMan)
        {
            float distance = Vector3.Distance(
                bucket.position,
                burningMan.position
            );

            if (distance <= manRange)
            {
                reachedMan = true;
                stage = GuidanceStage.ExtinguishFire;

                Debug.Log("Man range reached.");

                UpdateBeacons();
            }
        }
    }

    public void BucketGrabbed()
    {
        bucketHeld = true;

        if (stage == GuidanceStage.FindBucket)
        {
            stage = GuidanceStage.GoToHydrant;
        }

        UpdateBeacons();
    }

    public void BucketDropped()
    {
        // Check position BEFORE reacting to the drop.
        CheckTargetRanges();

        bucketHeld = false;

        UpdateBeacons();
    }

    public void BucketFilled()
    {
        reachedHydrant = true;

        stage = GuidanceStage.GoToMan;
        reachedMan = false;

        Debug.Log("Bucket filled. Go to the man.");

        UpdateBeacons();
    }

    public void FireExtinguished()
    {
        stage = GuidanceStage.Complete;

        Debug.Log("Fire extinguished. Guidance complete.");

        UpdateBeacons();
    }

    private void UpdateBeacons()
    {
        bucketBeacon.SetActive(false);
        hydrantBeacon.SetActive(false);
        manBeacon.SetActive(false);

        switch (stage)
        {
            case GuidanceStage.FindBucket:

                bucketBeacon.SetActive(true);
                break;


            case GuidanceStage.GoToHydrant:

                if (bucketHeld)
                    hydrantBeacon.SetActive(true);
                else
                    bucketBeacon.SetActive(true);

                break;


            case GuidanceStage.FillBucket:

                // Once you're close enough to the hydrant,
                // keep the hydrant highlighted until filling.
                hydrantBeacon.SetActive(true);
                break;


            case GuidanceStage.GoToMan:

                if (bucketHeld)
                    manBeacon.SetActive(true);
                else
                    bucketBeacon.SetActive(true);

                break;


            case GuidanceStage.ExtinguishFire:

                // IMPORTANT:
                // Once man range has been reached,
                // this beacon stays on even after dropping the bucket.
                manBeacon.SetActive(true);
                break;


            case GuidanceStage.Complete:

                // All beacons remain off.
                break;
        }
    }
}