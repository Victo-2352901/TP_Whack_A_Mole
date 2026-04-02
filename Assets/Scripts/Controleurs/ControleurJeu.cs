using System.Collections;
using UnityEngine;

public class ControleurJeu : MonoBehaviour
{
    public static ControleurJeu instance;

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
        instance = this;
    }

    // Update is called once per frame
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

    public void AjouterPoint()
    {
        points += 10;
        ControleurUI.Instance.ActualiserPoint(points);
    }

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

    public void Fin()
    {
        jeuEnCour = false;

        ControleurUI.Instance.CacherStats();
        ControleurUI.Instance.AfficherMenuFin(points);

    }
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
