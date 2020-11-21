using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>Gatling</c> initialise les attributs des cartes Gatling
/// </summary>
public class Gatling : Card
{
    public Gatling()
    {
        cardName = "GATLING";
        cardDescription = "Tous les autres joueurs perdent 1 PV";
        cardImage = Resources.Load<Sprite>("Cards/ImgCard/gatling");

    }

    /// <summary>
    /// Action lorsque la carte est joué
    /// </summary>
    public override void Play()
    {
        bool isDead;
        SoundManagerScript.PlaySound("Gatling");
        GameObject.Find("GameManager").GetComponent<GameManager>().addMessage("", "Utilise une Gatling");

        int nb_players = GameObject.Find("GameManager").GetComponent<GameManager>().Personnages.Count;
        for(int i=0; i<nb_players; i++)
        {
            isDead = false;
            if(GameObject.Find("GameManager").GetComponent<GameManager>().currentPersonnage != GameObject.Find("GameManager").GetComponent<GameManager>().Personnages[i])
            {
                isDead = GameObject.Find("GameManager").GetComponent<GameManager>().Personnages[i].GetComponent<ThisPersonnage>().GetPersonnage().takeDamageHeal(-1);
                if (isDead)
                {
                    nb_players --;
                    i--;
                }
            }
        }

    }

    public override void PlayBot(int x)
    {
        Play();
    }
}

