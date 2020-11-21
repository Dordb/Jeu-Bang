using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>Biere</c> initialise les attributs des cartes Biere
/// </summary>
public class Biere : Card
{
public Biere()
    {
        cardName = "BIERE";
        cardDescription = "Regagne 1 PV";
        cardImage = Resources.Load<Sprite>("Cards/ImgCard/Biere");
    }

    /// <summary>
    /// Action lorsque la carte est joué
    /// </summary>
    public override void Play()
    {
        Personnage target;
        // On récupère le personnage cible, qui correspond au personnage assigné à la zone de drop de la carte
        target = GameObject.Find("PlayerAreaGlob").GetComponent<ThisPersonnage>().GetPersonnage();

        target.takeDamageHeal(1);

        SoundManagerScript.PlaySound("Biere");
        GameObject.Find("GameManager").GetComponent<GameManager>().addMessage("", "Boit une Biere");
    }

    public void PlayBot()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().currentPersonnage.GetComponent<ThisPersonnage>().GetPersonnage().takeDamageHeal(1);
        Debug.Log("Boit une Biere");
        SoundManagerScript.PlaySound("Biere");
        GameObject.Find("GameManager").GetComponent<GameManager>().addMessage("", "Boit une Biere");

    }

    public override void PlayBot(int x)
    {
        PlayBot();
    }
}
