using System.Collections;
using TMPro;
using UnityEngine;


public class TexteTerminal : MonoBehaviour
{
    
    public GameObject terminalObject;
    public TextMeshProUGUI terminal;
    public GameObject touchesDeplacementObject;
    public GameObject joueur;
    public AudioSource sonTerminal;


    [TextArea] public string texteGenerateur1 = "";
    [TextArea] public string texteGenerateur2 = "";
    [TextArea] public string texteLabo = "";
    [TextArea] public string texteEnergieRetablie = "";
    [TextArea] public string texteMortEnnemi = "";


    public float vitesseEcriture = 0.05f;
    public float delaiEntreTextes = 2f;

    public GestionEnergie gestionEnergie;
    public EnnemiScript ennemiScript;
    private JoueurCollisions scriptCollisions;


    private CharacterController controller;

    private bool terminalDejaAffiche = false;
    private bool texteLaboAffiche = false;
    private bool texteEnergieAffiche = false;
    private bool texteMortAffiche = false;

    public bool estMort = false;


    void Start()
    {
        if (terminalObject != null)
            terminalObject.SetActive(false);

        if (joueur != null)
            scriptCollisions = joueur.GetComponent<JoueurCollisions>();

        touchesDeplacementObject.SetActive(true);

        controller = joueur.GetComponent<CharacterController>();

    }


    void Update()
    {
        
        if (scriptCollisions.afficherTerminal && !terminalDejaAffiche)
        {
            terminalDejaAffiche = true;
            StartCoroutine(AfficherDialogueGenerateur());
        }

        if (scriptCollisions.checkpointLaboratoireBool && !texteLaboAffiche)
        {
            texteLaboAffiche = true;
            StartCoroutine(AfficherTexteUnique(texteLabo));
        }
        

        if (gestionEnergie.energieRetablie && !texteEnergieAffiche)
        {
            texteEnergieAffiche = true;
            StartCoroutine(AfficherTexteUnique(texteEnergieRetablie));
        }

        if (ennemiScript.estMort && !texteMortAffiche)
        {
            texteMortAffiche = true;
        }

        GererDeplacementJoueur();
    }
    void GererDeplacementJoueur()
    {
        if (controller.velocity.magnitude > 0.1f)
        {
            touchesDeplacementObject.SetActive(false);
        }
    }

    IEnumerator AfficherDialogueGenerateur()
    {
        if (terminalObject != null)
            terminalObject.SetActive(true);

        yield return StartCoroutine(AfficherTexte(texteGenerateur1));
        yield return new WaitForSeconds(delaiEntreTextes);
        yield return StartCoroutine(AfficherTexte(texteGenerateur2));
    }

    IEnumerator AfficherTexteUnique(string texte)
    {
        if (terminalObject != null)
            terminalObject.SetActive(true);

        yield return StartCoroutine(AfficherTexte(texte));
    }

    IEnumerator AfficherTexte(string texte)
    {
        terminal.text = "";

        if (sonTerminal != null)
            sonTerminal.Play();

        foreach (char lettre in texte)
        {
            terminal.text += lettre;
            yield return new WaitForSeconds(vitesseEcriture);
        }

        if (sonTerminal != null)
            sonTerminal.Stop();
    }

}