using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>CoupDeFoudre</c> initialise les attributs des cartes CoupDeFoudre
/// </summary>
public class CoupDeFoudre : Card
{
    public CoupDeFoudre()
    {
        cardName = "COUP DE FOUDRE";
        cardDescription = "Force n'importe quel autre joueur a defausser 1 carte";
        cardImage = Resources.Load<Sprite>("Cards/ImgCard/CoupdeFoudre");
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
