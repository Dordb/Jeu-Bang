using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>Saloon</c> initialise les attributs des cartes Saloon
/// </summary>
public class Saloon : Card
{
    public Saloon(){
        cardName = "SALOON";
        cardDescription = "Tous les joueurs se soignent 1 PV";
        cardImage = Resources.Load<Sprite>("Cards/ImgCard/Saloon");
    }

    /// <summary>
    /// Action lorsque la carte est joué
    /// </summary>
    public override void Play()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().addMessage("", "Saloon");

        int nb_players = GameObject.Find("GameManager").GetComponent<GameManager>().Personnages.Count;
        for (int i = 0; i < nb_players; i++)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().Personnages[i].GetComponent<ThisPersonnage>().GetPersonnage().takeDamageHeal(1);
        }
    }

    public override void PlayBot(int x)
    {
        Play();
    }
}
