using System.Collections;
using UnityEngine;

public class StartMenuController : MonoBehaviour
{
    [Header("Start Screen")]
    public CanvasGroup startScreen;

    [Header("Fade")]
    public float fadeDuration = 2f;

    private bool openingEyes = false;

    public void StartGame()
    {
        if (openingEyes)
            return;

        openingEyes = true;

        // Prevent clicking anything else during the fade
        startScreen.interactable = false;
        startScreen.blocksRaycasts = false;

        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        float elapsed = 0f;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;

            startScreen.alpha =
                Mathf.Lerp(1f, 0f, elapsed / fadeDuration);

            yield return null;
        }

        startScreen.alpha = 0f;

        // Completely remove the start screen once eyes are open
        startScreen.gameObject.SetActive(false);

        Debug.Log("Player opened their eyes.");
    }
}