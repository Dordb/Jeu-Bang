using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>Sheriff</c> initialise les attributs d'un Personnage ayant le role de shérif
/// </summary>
public class Sheriff : Personnage
{
    public Sheriff()
    {
        role = "Sheriff";
        health = 5;
        healthMax = 5;
    }


}
