using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>HorsLaLoi</c> initialise les attributs d'un Personnage ayant le role d'Hors la loi
/// </summary>
public class HorsLaLoi : Personnage
{
    public HorsLaLoi()
    {
        role = "Hors La Loi";
        health = 3;
        healthMax = 3;
    }
}
