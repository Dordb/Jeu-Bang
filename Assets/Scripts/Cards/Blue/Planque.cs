using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>Planque</c> initialise les attributs des cartes Planque
/// </summary>
public class Planque : Card
{
    public Planque()
    {
        cardName = "PLANQUE";
        isBlue = true;
        cardDescription = "Vous avez 1 chance sur 4 d'eviter un Bang!";
        cardImage = Resources.Load<Sprite>("Cards/ImgCard/Planque");
    }

    /// <summary>
    /// Action lorsque la carte est joué
    /// </summary>
    public override void Play()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().addMessage("", "Planque");
    }

    public override void PlayBot(int i)
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().addMessage("", "Planque");

        GameObject player = GameObject.Find("GameManager").GetComponent<GameManager>().currentPersonnage;

        player.GetComponent<ThisBot>().addCard(i);

    }
}
