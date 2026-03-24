using UnityEngine;

public class ControleurJeu : MonoBehaviour
{
    public ControleurJeu instance;

    private bool jeuEnCour = false;

    private int point = 0;
    private float temps = 60f;

    [SerializeField]
    private GameObject menuDemarrer;

    [SerializeField]
    private GameObject menuFin;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        menuDemarrer.SetActive(true);
        menuFin.SetActive(false);
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (jeuEnCour)
        {
            temps -= Time.deltaTime;

            if (temps < 0)
            {
                
            }
        }   
    }
    
    public void AjouterPoint()
    {
        point += 10;
    }

    public void Demarrer()
    {
        temps = 60f;
        point = 0;
        jeuEnCour = true;

        menuDemarrer.SetActive(false);
    }

    public void Fin()
    {
        jeuEnCour = false;
        menuFin.SetActive(true);

    }
}
