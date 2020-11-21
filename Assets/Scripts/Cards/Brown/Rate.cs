using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>Rate</c> initialise les attributs des cartes Rate
/// </summary>
public class Rate : Card
{
    public Rate()
    {
        cardName = "RATE!";
        cardDescription = "Annule un BANG!";
        cardImage = Resources.Load<Sprite>("Cards/ImgCard/Rate");
    }

    /// <summary>
    /// Action lorsque la carte est joué
    /// </summary>
    public override void Play()
    {


        SoundManagerScript.PlaySound("Nope");
    }

    public override void PlayBot(int x)
    {
        Play();
    }
}
