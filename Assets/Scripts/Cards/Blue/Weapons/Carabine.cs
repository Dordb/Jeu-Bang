using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>Carabine</c> initialise les attributs des cartes Carabine
/// </summary>
public class Carabine : Weapon
{
    public Carabine()
    {
        shot_range = 4;
        cardName = "CARABINE";
        isBlue = true;
        cardDescription = "Distance de tir augmentée a 4";
        cardImage = Resources.Load<Sprite>("Cards/ImgCard/Carabine");
    }


}
