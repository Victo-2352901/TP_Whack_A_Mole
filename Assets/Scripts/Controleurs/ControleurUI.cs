using UnityEngine;

public class ControleurUI : MonoBehaviour
{

    public static ControleurUI Instance;

    [SerializeField]
    private GameObject menuDemarrer;

    [SerializeField]
    private GameObject menuFin;

    [SerializeField]
    private GameObject statistique;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instance = this;
        AfficherMenuDemarrer();
        CacherMenuFin();
        CacherStats();
    }



    //// Section en rapport avec le menu de démarrage

    /// <summary>
    /// Affiche le menu de de démarrage
    /// </summary>
    public void AfficherMenuDemarrer()
    {
        menuDemarrer.SetActive(true);
    }


    /// <summary>
    /// Cache le menu de de démarrage
    /// </summary>
    public void CacherMenuDemarrer()
    {
        menuDemarrer.SetActive(false);
    }


    //// Section en rapport avec le menu de fin

    /// <summary>
    /// Affiche le menu de fin
    /// </summary>
    public void AfficherMenuFin()
    {
        menuFin.SetActive(true);
    }

    /// <summary>
    /// Cache le menu de fin
    /// </summary>
    public void CacherMenuFin()
    {
        menuFin.SetActive(false);
    }


    //// Section en rapport avec les statistiques

    /// <summary>
    /// Affiche les éléments UI des statistiques
    /// </summary>
    public void AfficherStats()
    {

    }


    /// <summary>
    /// Cache les éléments UI des statistiques
    /// </summary>
    public void CacherStats() 
    { 
    
    }

    /// <summary>
    /// Actualise le nombre de point afficher
    /// </summary>
    /// <param name="points">Le nombre de point du joueur</param>
    public void ActualiserPoint(int points)
    {
        
    }

    /// <summary>
    /// Actualise le temps restant afficher
    /// </summary>
    /// <param name="tempsRestant">Le temps restant</param>
    public void ActualiserTemps(float tempsRestant)
    {

    }
}


