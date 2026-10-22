using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GestionScenes : MonoBehaviour
{
    [Header("Fondu visuel")]
    public Image fadeImage;         // Image UI qui couvre l'écran pendant le fondu.
    public float fadeDuration = 1f; // Durée du fondu en secondes.

    [Header("Fondu audio")]
    public AudioSource audioSource; // Source dont le volume suit le fondu.

    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    // À relier au bouton « Commencer » dans l'Inspector Unity.
    public void CommencerJeu()
    {
        StartCoroutine(FadeEtCharger("ImagesDebut"));
    }

    // À relier au bouton « Quitter ». Dans l'éditeur, arrête le mode Play.
    public void QuitterJeu()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    // Le fondu se déroule sur plusieurs frames; la scène est chargée à sa fin.
    private IEnumerator FadeEtCharger(string nomScene)
    {
        float timer = 0f;
        Color couleur = fadeImage.color;
        float volumeInitial = audioSource != null ? audioSource.volume : 0f;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float t = Mathf.Clamp01(timer / fadeDuration);

            couleur.a = t;
            fadeImage.color = couleur;

            if (audioSource != null)
            {
                audioSource.volume = Mathf.Lerp(volumeInitial, 0f, t);
            }

            yield return null;
        }

        if (audioSource != null)
        {
            audioSource.volume = 0f;
        }

        SceneManager.LoadScene(nomScene);
    }

    // Au démarrage, part d'un écran opaque puis révèle la scène en fondu.
    private IEnumerator FadeIn()
    {
        float timer = 0f;
        Color couleur = fadeImage.color;
        couleur.a = 1f;
        fadeImage.color = couleur;

        float volumeFinal = audioSource != null ? audioSource.volume : 1f;
        if (audioSource != null)
        {
            audioSource.volume = 0f;
        }

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float t = Mathf.Clamp01(timer / fadeDuration);

            couleur.a = 1f - t;
            fadeImage.color = couleur;

            if (audioSource != null)
            {
                audioSource.volume = Mathf.Lerp(0f, volumeFinal, t);
            }

            yield return null;
        }

        couleur.a = 0f;
        fadeImage.color = couleur;
    }
}
