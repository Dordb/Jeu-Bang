using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Class <c>Adjoint</c> initialise les attributs d'un Personnage ayant le role d'adjoint
/// </summary>
public class Adjoint : Personnage
{
    public Adjoint()
    {
        role = "Adjoint";
        health = 3;
        healthMax = 3;
    }
}
