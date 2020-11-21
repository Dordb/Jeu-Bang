using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>Mustang</c> initialise les attributs des cartes Mustang
/// </summary>
public class Mustang : Card
{
    public Mustang()
    {
        cardName = "MUSTANG";
        isBlue = true;
        cardDescription = "Les autres joueurs vous voit à une distance augmentée de 1";
        cardImage = Resources.Load<Sprite>("Cards/ImgCard/Mustang");
    }

    /// <summary>
    /// Action lorsque la carte est joué
    /// </summary>
    public override void Play()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().addMessage("", "Mustang");

        Personnage target;
        // On récupère le personnage cible, qui correspond au personnage assigné à la zone de drop de la carte
        target = GameObject.Find("PlayerAreaGlob").GetComponent<ThisPersonnage>().GetPersonnage();

        target.SetHided(1);

    }

    public override void PlayBot(int i)
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().addMessage("", "Mustang");

        GameObject player = GameObject.Find("GameManager").GetComponent<GameManager>().currentPersonnage;

        player.GetComponent<ThisBot>().addCard(i);

        player.GetComponent<ThisPersonnage>().GetPersonnage().SetHided(1);
    }


}
