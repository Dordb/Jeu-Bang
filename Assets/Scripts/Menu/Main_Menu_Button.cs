using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


/// <summary>
/// Class <c>Main_Menu_Button</c> gère les boutons du menu principal
/// </summary>
public class Main_Menu_Button : MonoBehaviour
{
    private static bool isOption = false;
    [SerializeField] private GameObject panelMenuMain;
    [SerializeField] private GameObject panelOptionMain;

    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (isOption)
            {
                ExitOptions();
            }
        }
    }


    /// <summary>
    /// Méthode qui change la scene pour aller sur celle du jeu
    /// </summary>
    public void Jouer()
    {
        Debug.Log("Lancement de la partie");
        SceneManager.LoadScene(1);
    }

    /// <summary>
    /// Méthode qui permet de modifier les Options du jeu
    /// </summary>
    public void Options()
    {
        isOption = true;
        panelMenuMain.SetActive(false);
        panelOptionMain.SetActive(true);
        Debug.Log("Options");
    }

    public void ExitOptions()
    {
        isOption = true;
        panelOptionMain.SetActive(false);
        panelMenuMain.SetActive(true);
        Debug.Log("Options");
    }

    /// <summary>
    /// Methode qui permet de quitter le jeu
    /// </summary>
    public void Quitter()
    {
        Debug.Log("Fermeture du programme");
        Application.Quit();
    }
}
