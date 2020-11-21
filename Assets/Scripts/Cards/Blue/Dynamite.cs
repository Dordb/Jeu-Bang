using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>Dynamite</c> initialise les attributs des cartes Dynamite
/// </summary>
public class Dynamite : Card
{
    public Dynamite()
    {
        cardName = "DYNAMITE";
        isBlue = true;
        cardDescription = "Dynamite BOOOOOOM";
        cardImage = Resources.Load<Sprite>("Cards/ImgCard/Dynamite");
    }

    /// <summary>
    /// Action lorsque la carte est joué
    /// </summary>
    public override void Play()
    {
        
    }

    public override void PlayBot(int x)
    {
        
    }
}
