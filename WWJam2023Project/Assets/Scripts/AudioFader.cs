using System.Collections;
using UnityEngine;

public class AudioFader : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource; // assign the AudioSource in the inspector
    [SerializeField] private float fadeDuration = 1f; // duration of the fade in seconds

    public float minVolume = 0.0f;
    public float maxVolume = 1.0f;
    private float currentVolume;

    private void Start()
    {
        currentVolume = audioSource.volume;
    }

    public void StartFadeOut()
    {
        currentVolume = audioSource.volume;
        StartCoroutine(Fade(minVolume));
    }

    public void StartFadeIn()
    {
        currentVolume = audioSource.volume;
        StartCoroutine(Fade(maxVolume));
    }

    private IEnumerator Fade(float targetVolume)
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            currentVolume = Mathf.Lerp(audioSource.volume, targetVolume, elapsedTime / fadeDuration);
            audioSource.volume = currentVolume;
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        currentVolume = targetVolume;
        audioSource.volume = currentVolume;
    }
}
