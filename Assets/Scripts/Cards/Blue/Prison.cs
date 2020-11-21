using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>Prison</c> initialise les attributs des cartes Prison
/// </summary>
public class Prison : Card
{
    public Prison()
    {
        cardName = "PRISON";
        isBlue = true;
        cardDescription = "Met un joueur en Prison";
        cardImage = Resources.Load<Sprite>("Cards/ImgCard/Prison");
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
