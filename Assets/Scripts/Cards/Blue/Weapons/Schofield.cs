using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>Schofield</c> initialise les attributs des cartes Schofield
/// </summary>
public class Schofield : Weapon
{
    public Schofield()
    {
        shot_range = 2;
        cardName = "SCHOFIELD";
        isBlue = true;
        cardDescription = "Distance de tir augmentée a 2";
        cardImage = Resources.Load<Sprite>("Cards/ImgCard/Schofield");
    }


}
