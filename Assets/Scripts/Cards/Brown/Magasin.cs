using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>Magasin</c> initialise les attributs des cartes Magasin
/// </summary>
public class Magasin : Card
{
    public Magasin()
    {
        cardName = "MAGASIN";
        cardDescription = "Retourne autant de cartes de la pioche que de personnages en jeu. Chaque joueur choisit et prend une de ces cartes en commençant par celui qui a joué la carte et en tournant dans le sens des aiguilles d'une montre";
        cardImage = Resources.Load<Sprite>("Cards/ImgCard/Magasin");
    }

    /// <summary>
    /// Action lorsque la carte est joué
    /// </summary>
    public override void Play()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().addMessage("", "Magasin");

        GameManager gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        int posDraw = gm.Personnages.IndexOf(gm.currentPersonnage);

        for (int i = 0; i < gm.Personnages.Count; i++)
        {
            gm.currentPersonnage = gm.Personnages[posDraw];
            if(gm.currentPersonnage.GetComponent<ThisPersonnage>().GetPersonnage().GetHealth() != 0)
            {
                gm.DrawCard(1);
            }

            posDraw = (posDraw + 1) % gm.Personnages.Count;
        }

        gm.SetCur(posDraw);

        gm.currentPersonnage = gm.Personnages[gm.GetCur()];
    }

    public override void PlayBot(int x)
    {
        Play();
    }
}
