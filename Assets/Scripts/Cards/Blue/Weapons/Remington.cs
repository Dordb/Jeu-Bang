using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>Remington</c> initialise les attributs des cartes Remington
/// </summary>
public class Remington : Weapon
{
    public Remington()
    {
        shot_range = 4;
        cardName = "REMINGTON";
        isBlue = true;
        cardDescription = "Distance de tir augmentée a 4";
        cardImage = Resources.Load<Sprite>("Cards/ImgCard/Remington");
    }


}
