using UnityEngine;

public class MirrorPortalInteraction : MonoBehaviour
{
    [Header("Mirror / Portal")]
    public GameObject mirrorVisual;
    public GameObject portalVisual;

    [Header("Renderers")]
    public Renderer mirrorRenderer;

    [Header("Player")]
    public Transform xrOrigin;
    public Transform citySpawnPoint;

    [Header("Hover")]
    public Transform mirrorTransform;
    public Transform portalTransform;
    public float hoverScaleMultiplier = 1.05f;

    [Header("Mirror Glow")]
    public Color mirrorGlowColor = Color.cyan;
    public float mirrorMinGlow = 0.5f;
    public float mirrorMaxGlow = 4f;

    [Header("Pulse")]
    public float pulseSpeed = 2f;

    private Material mirrorMaterial;

    private Vector3 mirrorOriginalScale;
    private Vector3 portalOriginalScale;

    private bool portalActive = false;
    private bool hovering = false;

    void Start()
    {
        mirrorOriginalScale = mirrorTransform.localScale;
        portalOriginalScale = portalTransform.localScale;

        // Element 2 = third material slot
        mirrorMaterial = mirrorRenderer.materials[2];

        mirrorMaterial.EnableKeyword("_EMISSION");

        mirrorVisual.SetActive(true);
        portalVisual.SetActive(false);
    }

    void Update()
    {
        // Constant glow pulse while the mirror is active
        if (!portalActive)
        {
            float pulse =
                (Mathf.Sin(Time.time * pulseSpeed) + 1f) / 2f;

            float intensity =
                Mathf.Lerp(
                    mirrorMinGlow,
                    mirrorMaxGlow,
                    pulse
                );

            // Slightly stronger glow while hovering
            if (hovering)
                intensity *= 1.5f;

            mirrorMaterial.SetColor(
                "_EmissionColor",
                mirrorGlowColor * intensity
            );
        }
    }

    public void HoverEnter()
    {
        hovering = true;

        if (!portalActive)
        {
            mirrorTransform.localScale =
                mirrorOriginalScale * hoverScaleMultiplier;
        }
        else
        {
            portalTransform.localScale =
                portalOriginalScale * hoverScaleMultiplier;
        }
    }

    public void HoverExit()
    {
        hovering = false;

        if (!portalActive)
        {
            mirrorTransform.localScale = mirrorOriginalScale;
        }
        else
        {
            portalTransform.localScale = portalOriginalScale;
        }
    }

    public void Interact()
    {
        // First selection: mirror becomes portal
        if (!portalActive)
        {
            portalActive = true;

            mirrorTransform.localScale = mirrorOriginalScale;

            mirrorVisual.SetActive(false);
            portalVisual.SetActive(true);

            Debug.Log("Mirror transformed into portal.");
        }

        // Second selection: teleport
        else
        {
            TeleportPlayer();
        }
    }

    private void TeleportPlayer()
    {
        xrOrigin.position = citySpawnPoint.position;
        xrOrigin.rotation = citySpawnPoint.rotation;

        Debug.Log("Player teleported to city.");
    }
}