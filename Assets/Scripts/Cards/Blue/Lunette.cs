using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>Lunette</c> initialise les attributs des cartes Lunette
/// </summary>
public class Lunette : Card
{
    public Lunette()
    {
        cardName = "LUNETTE";
        isBlue = true;
        cardDescription = "Voit tous les autres joueurs à une distance diminuée de 1.";
        cardImage = Resources.Load<Sprite>("Cards/ImgCard/Lunette");
    }

    /// <summary>
    /// Action lorsque la carte est joué
    /// </summary>
    public override void Play()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().addMessage("", "Lunette");

        Personnage target;
        // On récupère le personnage cible, qui correspond au personnage assigné à la zone de drop de la carte
        target = GameObject.Find("PlayerAreaGlob").GetComponent<ThisPersonnage>().GetPersonnage();

        target.SetViewDistance(2);

    }


    public override void PlayBot(int i)
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().addMessage("", "Lunette");

        GameObject player = GameObject.Find("GameManager").GetComponent<GameManager>().currentPersonnage;

        player.GetComponent<ThisBot>().addCard(i);

        player.GetComponent<ThisPersonnage>().GetPersonnage().SetViewDistance(2);
    }
}
