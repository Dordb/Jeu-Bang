using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>Duel</c> initialise les attributs des cartes Duel
/// </summary>
public class Duel : Card
{
    public Duel()
    {
        cardName = "DUEL";
        cardDescription = "L'adversaire defause 1 BANG!, puis c'est a vous, etc. Le premier qui ne le fait pas perd 1 PV";
        cardImage = Resources.Load<Sprite>("Cards/ImgCard/Duel");
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
