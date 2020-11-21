using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>Braquage</c> initialise les attributs des cartes Braquage
/// </summary>
public class Braquage : Card
{
    public Braquage()
    {
        cardName = "BRAQUAGE";
        cardDescription = "Vole 1 carte a une personne a distance 1";
        cardImage = Resources.Load<Sprite>("Cards/ImgCard/Braquage");
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
