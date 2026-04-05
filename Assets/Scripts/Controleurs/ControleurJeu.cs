using System.Collections;
using UnityEngine;

public class ControleurJeu : MonoBehaviour
{
    public static ControleurJeu Instance;

    private bool jeuEnCour = false;

    private int points = 0;
    private float temps = 60f;

    [SerializeField]
    private GameObject[] spawner;

    [SerializeField]
    private GameObject ciblePrefab;

    private float timerSpawn = 0f;
    public float intervalleSpawn = 2f;

    private GameObject cibleActuelle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instance = this;
    }

    /// <summary>
    /// S'occupe du bon fonctionnement du jeu
    /// </summary>
    void Update()
    {
        if (jeuEnCour)
        {
            temps -= Time.deltaTime;
            ControleurUI.Instance.ActualiserTemps(temps);

            timerSpawn -= Time.deltaTime;

            if (timerSpawn <= 0f)
            {
                SpawnCible();
                timerSpawn = intervalleSpawn;
            }



            if (temps < 0)
            {
                Fin();
            }
        }
    }

    /// <summary>
    /// Ajoute des points au joueurs et actualise le UI
    /// </summary>
    public void AjouterPoint()
    {
        points += 10;
        ControleurUI.Instance.ActualiserPoint(points);
    }

    /// <summary>
    /// Remet les bonnes données pour le début du jeu
    /// </summary>
    public void Demarrer()
    {
        temps = 60f;
        points = 0;
        jeuEnCour = true;

        ControleurUI.Instance.CacherMenuDemarrer();
        ControleurUI.Instance.AfficherStats();

        ControleurUI.Instance.ActualiserPoint(points);
        ControleurUI.Instance.ActualiserTemps(temps);
    }


    /// <summary>
    /// Arrête le jeu et affiche le menu de fin
    /// </summary>
    public void Fin()
    {
        jeuEnCour = false;

        ControleurUI.Instance.CacherStats();
        ControleurUI.Instance.AfficherMenuFin(points);

    }

    /// <summary>
    /// Si aucune cible est actuelle placer, fait apparaitre une cible à un endroit aléatoire pendant un bref moment
    /// </summary>
    void SpawnCible()
    {
        if (cibleActuelle == null)
        {
            int index = Random.Range(0, spawner.Length);
            Transform pointSpawn = spawner[index].transform;

            cibleActuelle = Instantiate(ciblePrefab, pointSpawn.position, pointSpawn.rotation);

            StartCoroutine(AutoDetruire(cibleActuelle));
        };
    }

    /// <summary>
    /// Détruis la cible automatiquement après un bref délai
    /// </summary>
    /// <param name="cible">La cible actuelle</param>
    /// <returns>Un temps d'attente</returns>
    public IEnumerator AutoDetruire(GameObject cible)
    {
        yield return new WaitForSeconds(1);

        if (cible != null)
        {
            Destroy(cible);
            cibleActuelle = null;
        }
    }
}
