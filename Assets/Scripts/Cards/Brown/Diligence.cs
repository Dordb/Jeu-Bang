using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>Diligence</c> initialise les attributs des cartes Diligence
/// </summary>
public class Diligence : Card
{
    public Diligence()
    {
        cardName = "DILIGENCE";
        cardDescription = "Pioche 3 cartes";
        cardImage = Resources.Load<Sprite>("Cards/ImgCard/Diligence");
    }

    /// <summary>
    /// Action lorsque la carte est joué
    /// </summary>
    public override void Play()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().DrawCard(3);
        GameObject.Find("GameManager").GetComponent<GameManager>().addMessage("", "Utilise une Diligence");
    }

    public override void PlayBot(int x)
    {
        Play();
    }
}
