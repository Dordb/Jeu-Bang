using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>Convoi</c> initialise les attributs des cartes Convoi
/// </summary>
public class Convoi : Card
{
    public Convoi()
    {
        cardName = "CONVOI";
        cardDescription = "Pioche 2 cartes";
        cardImage = Resources.Load<Sprite>("Cards/ImgCard/Convoi");
    }

    /// <summary>
    /// Action lorsque la carte est joué
    /// </summary>
    public override void Play()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().DrawCard(2);
        GameObject.Find("GameManager").GetComponent<GameManager>().addMessage("", "Utilise un Convoi");
    }

    public override void PlayBot(int x)
    {
        Play();
    }
}
