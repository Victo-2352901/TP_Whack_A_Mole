using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuDemarrer : MonoBehaviour
{
    [SerializeField]
    private GameObject menuDemarrer;

    void Start()
    {
        menuDemarrer.SetActive(true);
    }
    public void Demarrer()
    {
        menuDemarrer.SetActive(false);
        SceneManager.LoadScene("Jeu");
    }


}
