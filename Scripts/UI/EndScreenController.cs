using System.Collections;
using UnityEngine;

public class EndScreenController : MonoBehaviour
{
    [Header("End Screen")]
    public CanvasGroup endScreen;

    [Header("Timing")]
    public float delayBeforeFade = 2f;
    public float fadeDuration = 2f;

    private bool endingStarted = false;

    private void Start()
    {
        // Canvas stays ACTIVE, just invisible
        endScreen.alpha = 0f;
        endScreen.interactable = false;
        endScreen.blocksRaycasts = false;
    }

    public void ShowEndScreen()
    {
        if (endingStarted)
            return;

        endingStarted = true;

        Debug.Log("END SCREEN TRIGGERED");

        StartCoroutine(EndSequence());
    }

    private IEnumerator EndSequence()
    {
        yield return new WaitForSeconds(delayBeforeFade);

        float elapsed = 0f;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;

            endScreen.alpha =
                Mathf.Lerp(0f, 1f, elapsed / fadeDuration);

            yield return null;
        }

        endScreen.alpha = 1f;
        endScreen.interactable = true;
        endScreen.blocksRaycasts = true;

        Debug.Log("END SCREEN VISIBLE");
    }
}