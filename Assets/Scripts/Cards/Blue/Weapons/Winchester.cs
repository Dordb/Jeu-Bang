using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>Winchester</c> initialise les attributs des cartes Winchester
/// </summary>
public class Winchester : Weapon
{
    public Winchester()
    {
        shot_range = 5;
        cardName = "WINCHESTER";
        isBlue = true;
        cardDescription = "Distance de tir augmentée a 5";
        cardImage = Resources.Load<Sprite>("Cards/ImgCard/Winchester");
    }

}
