using UnityEngine;

public class DontDestroyManager : MonoBehaviour
{
    // Garde une seule instance du manager entre les changements de scène.
    private static DontDestroyManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Une copie placée dans une autre scène ne doit pas créer de doublon.
            Destroy(gameObject);
        }
    }
}
