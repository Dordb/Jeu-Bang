using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class <c>ThisPersonnage</c> 
/// définit les élément visuel des personnages
/// </summary>
[System.Serializable]
// Affichage des informations du joueur
public class ThisPersonnage : MonoBehaviour
{
    public Text health;
    public Text healthMax;
    public Text role;
    [SerializeField]public Personnage p;
    public List<int> hand;
    public GameObject board;

    public string id;

    public bool isPlayer = false;


 
    /// <summary>
    /// Actualise les attributs visuel
    /// </summary>
    private void Update()
    {
        health.text = p.GetHealth().ToString();
        healthMax.text = p.GetHealthMax().ToString();
        role.text = p.GetRole();
        hand = p.GetHand();


    }

    public void SetPersonnage(Personnage p)
    {
        this.p = p;
    }

    public Personnage GetPersonnage()
    {
        return p;
    }

}
