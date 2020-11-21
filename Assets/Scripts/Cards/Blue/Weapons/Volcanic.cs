using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>Volcanic</c> initialise les attributs des cartes Volcanic
/// </summary>
public class Volcanic : Weapon
{
    public Volcanic()
    {
        shot_range = 1;
        cardName = "VOLCANIC";
        isBlue = true;
        cardDescription = "Peut utiliser autant de BANG! qu'on le souhaite";
        cardImage = Resources.Load<Sprite>("Cards/ImgCard/Volcanic");
    }


}
