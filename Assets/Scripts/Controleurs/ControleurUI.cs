using TMPro;
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


    [SerializeField]
    private TextMeshProUGUI textePoint;

    [SerializeField]
    private TextMeshProUGUI texteTemps;

    [SerializeField]
    private TextMeshProUGUI texteScoreFinal;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instance = this;
        AfficherMenuDemarrer();
        CacherMenuFin();
        CacherStats();
        textePoint.text = "Point : 0";
        texteTemps.text = "Temps : 60s";
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
    public void AfficherMenuFin(int points)
    {
        menuFin.SetActive(true);

        texteScoreFinal.text = "Score final : " + points;
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
        statistique.SetActive(true);
    }


    /// <summary>
    /// Cache les éléments UI des statistiques
    /// </summary>
    public void CacherStats() 
    {
        statistique.SetActive(false);
    }

    /// <summary>
    /// Actualise le nombre de point afficher
    /// </summary>
    /// <param name="points">Le nombre de point du joueur</param>
    public void ActualiserPoint(int points)
    {
        textePoint.text = "Point: " + points;
    }

    /// <summary>
    /// Actualise le temps restant afficher
    /// </summary>
    /// <param name="tempsRestant">Le temps restant</param>
    public void ActualiserTemps(float tempsRestant)
    {
        texteTemps.text = "Temps restant : " + Mathf.FloorToInt(tempsRestant % 60f) + "s";
    }
}


