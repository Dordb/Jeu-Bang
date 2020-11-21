using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;




/// <summary>
/// Class <c>In_game_Menu</c> permet l'affichage d'un menu pause en cours de jeu
/// </summary>
public class In_game_Menu : MonoBehaviour
{
    [SerializeField] private GameObject panelMenu;
    [SerializeField] private GameObject panelOption;
    [SerializeField] private GameObject panelEnd;
    [SerializeField] private Text txtEnd;
    [SerializeField] private GameObject imgInfo;
    [SerializeField] private Text txtInfo;



    private static bool isActive = false;
    private static bool isActiveOption = false;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {

            if (isActive && !isActiveOption)
            {
                Continuer();
            }
            else if (isActive && isActiveOption)
            {
                OptionsExit();
            }
            else
            {
                Pause();
            }
        }


    }
    /// <summary>
    /// Méthode qui permet de reprendre le jeu
    /// </summary>
    public void Continuer()
    {
        Time.timeScale = 1;
        Debug.Log("Continue");
        panelMenu.SetActive(false);
        panelOption.SetActive(false);
        isActive = false;
        isActiveOption = false;
    }

    /// <summary>
    /// Méthode qui permet de mettre en pause le jeu
    /// </summary>
    public void Pause()
    {
        Time.timeScale = 0;
        Debug.Log("Pause");
        panelMenu.SetActive(true);
        isActive = true;
    }

    /// <summary>
    /// Méthode qui permet de modifier les Options
    /// </summary>
    public void Restart()
    {
        Time.timeScale = 1;
        Debug.Log("Restart");
        SceneManager.LoadScene(1);
    }

    public void Options()
    {
        Debug.Log("Options");
        panelMenu.SetActive(false);
        panelOption.SetActive(true);
        isActiveOption = true;
    }

    public void OptionsExit()
    {
        panelMenu.SetActive(true);
        panelOption.SetActive(false);
        isActiveOption = false;
    }

    public void infoGameHide()
    {
        imgInfo.SetActive(false);
    }

    public void infoGame(string info)
    {
        imgInfo.SetActive(true);
        txtInfo.text = info;

        //delay
        Invoke("infoGameHide", 1.3f);
    }

    /// <summary>
    /// Méthode qui permet d'aller sur la scene du menu principal
    /// </summary>
    public void Main_Menu()
    {
        Debug.Log("Retour au menu principal");
        SceneManager.LoadScene(0);
    }

    public void endGame(string winners)
    {
        txtEnd.text = winners.ToUpper();
        panelMenu.SetActive(false);
        panelOption.SetActive(false);
        panelEnd.SetActive(true);
    }
}
