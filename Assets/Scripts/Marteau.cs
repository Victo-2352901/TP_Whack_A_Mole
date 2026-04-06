using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

/// <summary>
/// Ce script est inspiré des notes de cours. 
/// </summary>
public class Marteau : MonoBehaviour
{


    private XRGrabInteractable grabInteractable;

    [SerializeField]
    private AudioSource audioSource;


    [SerializeField] private float amplitudeGrab = 0.5f;
    [SerializeField] private float dureeGrab = 0.1f;
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
            ControleurJeu.Instance.AjouterPoint();
            Destroy(collision.gameObject);
        }
    }

    // Provient des notes de cours

    /// <summary>
    /// Lance la vibration quand le marteau est pris
    /// </summary>
    /// <param name="args">Information de l'objet qui contient le component xr grab</param>
    private void OnGrabEntered(SelectEnterEventArgs args)
    {
        // Récupérer le contrôleur depuis l'interactor
        var controller = args.interactorObject.transform.GetComponent<XRBaseController>();

        audioSource.Play();

        controller.SendHapticImpulse(amplitudeGrab, dureeGrab);
    }


    /// <summary>
    /// Lance la vibration quand le marteau est déposé
    /// </summary>
    /// <param name="args">Information de l'objet qui contient le component xr grab</param>
    private void OnGrabExited(SelectExitEventArgs args)
    {
        // Vibration plus courte et moins forte au relâchement
        var controller = args.interactorObject.transform.GetComponent<XRBaseController>();

        controller.SendHapticImpulse(amplitudeGrab * 0.3f, dureeGrab * 0.5f);
    }
}
