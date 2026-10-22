using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class RecuperationDonnees : MonoBehaviour
{
    public GestionEnergie gestionEnergie;
    public JoueurCollisions joueurCollisions;

    public Transform joueur;
    public Transform[] objetsInteractifs;

    public Slider slider;

    public TextMeshProUGUI terminal;

    public float distanceActivation = 2f;
    public float vitesseAnimationScale = 2f;
    public float facteurScale = 1.1f;
    public float vitesseProgression = 0.05f;

    private bool progressionEnCours = false;
    private bool interactionTerminee = false;

    public AudioSource sonBarreProgression;

    public GameObject visuelAimant;
    public GameObject rapportDonnees;
    public GameObject barreDonnes;


    public bool donneesRecuperees = false;


    void Start()
    {
        slider.gameObject.SetActive(false);
        barreDonnes.SetActive(true);
        slider.value = 0f;
        terminal.text = "";
    }

    void Update()
    {
        //Lorsque les données sont récupérées l'aimant s'active
        if (donneesRecuperees)
        {
            ActiverAimant();
        }
        //La barre de progression des données est désactivé si l'énergie rétablie n'est pas actif
        if (gestionEnergie == null || !gestionEnergie.energieRetablie)
        {
            slider.gameObject.SetActive(false);
            return;
        }

        if (interactionTerminee)
        {
            return;
        }
        //Collision avec l'ordinateur
        if (joueurCollisions.joueurOrdinateur)
        {
            //Maintenir la touche E proche de l'ordinateur augmente la progression du slider pour la récupération des données
            if (Input.GetKey(KeyCode.E))
            {
                barreDonnes.SetActive(true);
                slider.gameObject.SetActive(true);

                if (slider.value < slider.maxValue)
                {
                    slider.value += vitesseProgression * Time.deltaTime;
                    progressionEnCours = true;

                    int pourcentage = Mathf.FloorToInt(slider.value / slider.maxValue * 100);
                    terminal.text = $"{pourcentage}%";

                    if (!sonBarreProgression.isPlaying)
                    {
                        sonBarreProgression.Play();
                    }

                    if (pourcentage == 100 & !donneesRecuperees)
                    {
                        donneesRecuperees = true;
                        AfficheFeuille();
                        joueurCollisions.toucheE.SetActive(false);
                        joueurCollisions.toucheEMaintenir.SetActive(false);

                    }


                }
                //Si la progression est complétée, le son arrête de jouer et les données sont sauvegardé
                else
                {
                    if (sonBarreProgression.isPlaying)
                    {
                        sonBarreProgression.Stop();
                    }

                    if (progressionEnCours)
                    {
                        terminal.text = "Données sauvegardées dans 'RED'";
                        progressionEnCours = false;

                        slider.gameObject.SetActive(false);
                        StartCoroutine(CacherMessageApresDelai(3f));
                        interactionTerminee = true;
                        JoueurCollisions collisions = joueurCollisions;
                        collisions.toucheEMaintenir.SetActive(false);
                    }
                }
            }
            else
            {
                if (sonBarreProgression.isPlaying)
                {
                    sonBarreProgression.Stop();
                }
            }
        }
        else
        {
            slider.gameObject.SetActive(false);
        }
    }

    IEnumerator CacherMessageApresDelai(float delai)
    {
        yield return new WaitForSeconds(delai);
        terminal.text = "";
    }

    public void AfficheFeuille()
    {
        //Lorsque les donées sont récupéré, le rapport s'affiche au joueur et le texte s'efface
        if (donneesRecuperees)
        {
            donneesRecuperees = true;
            rapportDonnees.SetActive(true);
            joueurCollisions.toucheEMaintenir.SetActive(false);
            joueurCollisions.joueurOrdinateur = false;
            barreDonnes.SetActive(false);
            terminal.text = "";
        }
    }
    public void ActiverAimant() {
        // Lorsque le pourcentage est a 100%, l'aimant s'active ( booléenne dans le script de collision de joueur)
        joueurCollisions.aimantActif = true;

        // L'aimant apparait
        visuelAimant.SetActive(true);
    }

}
