using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using static UnityEngine.Rendering.GPUSort;

/// <summary>
/// Ce script est inspiré des notes de cours. 
/// </summary>
public class Marteau : MonoBehaviour
{


    private XRGrabInteractable grabInteractable;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private GameObject cube;

    [SerializeField]
    private AudioClip[] sons;


    [SerializeField] private float amplitudeGrab = 0.5f;
    [SerializeField] private float dureeGrab = 0.1f;

    /// https://www.youtube.com/watch?v=LKq45FNopYU&t=102s
    private XRBaseInputInteractor controlleur;

    bool marteauAttrape = false;

    /// <summary>
    /// 
    /// </summary>
    private void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
    }

    /// <summary>
    /// Assigne les méthodes à leurs actions dans le jeu
    /// </summary>
    void OnEnable()
    {
        grabInteractable.selectEntered.AddListener(OnGrabEntered);
        grabInteractable.selectExited.AddListener(OnGrabExited);
    }

    /// <summary>
    /// Désassgigne les méthodes À la fin du jeu
    /// </summary>
    void OnDisable()
    {
        grabInteractable.selectEntered.RemoveListener(OnGrabEntered);
        grabInteractable.selectExited.RemoveListener(OnGrabExited);
    }

    /// <summary>
    /// Quand une collision est détecter. Vérifie si le marteau a toucher une cible et si oui, la détruis ainsi.
    /// </summary>
    /// <param name="collision">L'objet avec lequel le marteau a fais collision</param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cible"))
        {
            collision.gameObject.tag = "DejaTouche";

            JouerVibrationCible();
            JouerSonDestruction();
            ControleurJeu.Instance.AjouterPoint();
            Destroy(collision.gameObject);
            ControleurJeu.Instance.ChangerCibleActuelle();
        }
    }

    // Provient des notes de cours

    /// <summary>
    /// Lance la vibration quand le marteau est pris
    /// </summary>
    /// <param name="args">Information de l'objet qui contient le component xr grab</param>
    private void OnGrabEntered(SelectEnterEventArgs args)
    {
        marteauAttrape = true;
        if (marteauAttrape)
        {
            cube.SetActive(false);
        }
        // Récupérer le contrôleur depuis l'interactor
        controlleur = args.interactorObject.transform.GetComponent<XRBaseInputInteractor>();

        audioSource.clip = sons[0];
        audioSource.Play();

        controlleur.SendHapticImpulse(1, 1);
    }


    /// <summary>
    /// Lance la vibration quand le marteau est déposé
    /// </summary>
    /// <param name="args">Information de l'objet qui contient le component xr grab</param>
    private void OnGrabExited(SelectExitEventArgs args)
    {
        // Vibration plus courte et moins forte au relâchement
        controlleur = args.interactorObject.transform.GetComponent<XRBaseInputInteractor>();

        controlleur.SendHapticImpulse(amplitudeGrab * 0.3f, dureeGrab * 0.5f);

        controlleur = null;
    }

    /// <summary>
    /// Envoi une vibration dans le controleur
    /// </summary>
    private void JouerVibrationCible()
    {
        if (controlleur != null)
        {
            controlleur.SendHapticImpulse(amplitudeGrab * 1f, dureeGrab * 0.3f);
        }
    }

    /// <summary>
    /// Joue le son de destruction 
    /// </summary>
    /// <returns>Le temps d'attente de la longueur du son</returns>
    private void JouerSonDestruction()
    {
        audioSource.clip = sons[1];
        audioSource.Play();
    }
}
