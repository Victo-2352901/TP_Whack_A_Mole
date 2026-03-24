using UnityEngine;

public class ControleurJeu : MonoBehaviour
{
    public static ControleurJeu instance;

    private bool jeuEnCour = false;

    private int point = 0;
    private float temps = 60f;

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

            if (temps < 0)
            {
                ControleurUI.Instance.AfficherMenuFin();    
            }
        }   
    }
    
    public void AjouterPoint()
    {
        point += 10;
        ControleurUI.Instance.ActualiserPoint(point);
    }

    public void Demarrer()
    {
        temps = 60f;
        point = 0;
        jeuEnCour = true;

        ControleurUI.Instance.CacherMenuDemarrer();
        ControleurUI.Instance.AfficherStats();

        ControleurUI.Instance.ActualiserPoint(point);
        ControleurUI.Instance.ActualiserTemps(temps);
    }

    public void Fin()
    {
        jeuEnCour = false;

        ControleurUI.Instance.CacherStats();
        ControleurUI.Instance.AfficherMenuFin();

    }
}
