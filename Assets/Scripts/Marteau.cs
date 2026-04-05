using UnityEngine;

public class Marteau : MonoBehaviour
{

    /// <summary>
    /// Quand une collision est détecter. Vérifie si le marteau a toucher une cible et si oui, la détruis ainsi.
    /// </summary>
    /// <param name="collision">L'objet avec lequel le marteau a fais collision</param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cible"))
        {
            ControleurJeu.Instance.AjouterPoint();
            Destroy(collision.gameObject);
        }
    }
}
