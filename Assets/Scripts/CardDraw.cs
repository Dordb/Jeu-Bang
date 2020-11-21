using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>CardDraw</c> créer une liste de toute les cartes 
/// </summary>
public class CardDraw
{
    public List<Card> cardList;

    public CardDraw()
    {
        cardList = new List<Card>();
        int nbBang = 25;
        int nbRate = 12;
        int nbBiere = 6;
        int nbIndiens = 2;
        int nbDuel = 3;
        int nbBraquage = 4;
        int nbMagasin = 2;
        int nbCoupdeFoudre = 4;
        int nbConvoi = 2;
        int nbDiligence = 1;
        int nbSaloon = 1;
        int nbGatling = 1;
        int nbPlanque = 2;
        int nbDynamite = 1;
        int nbLunette = 1;
        int nbPrison = 3;
        int nbMustang = 2;
        int nbCarabine = 1;
        int nbRemington = 1;
        int nbWinchester = 1;
        int nbSchofield = 3;
        int nbVolcanic = 2;

        for (int i=0; i < nbBang; i++)
        {
            cardList.Add(new Bang());
        }
        for (int i = 0; i < nbRate; i++)
        {
            cardList.Add(new Rate());
        }
        for (int i = 0; i < nbBiere; i++)
        {
            cardList.Add(new Biere());
        }
        for (int i = 0; i < nbIndiens; i++)
        {
            cardList.Add(new Indiens());
        }
        /*for (int i = 0; i < nbDuel; i++)
        {
            cardList.Add(new Duel());
        }*/
        /*for (int i = 0; i < nbBraquage; i++)
        {
            cardList.Add(new Braquage());
        }*/
        for (int i = 0; i < nbMagasin; i++)
        {
            cardList.Add(new Magasin());
        }
        /*for (int i = 0; i < nbCoupdeFoudre; i++)
        {
            cardList.Add(new CoupDeFoudre());
        }*/
        for (int i = 0; i < nbConvoi; i++)
        {
            cardList.Add(new Convoi());
        }
        for (int i = 0; i < nbDiligence; i++)
        {
            cardList.Add(new Diligence());
        }
        for (int i = 0; i < nbSaloon; i++)
        {
            cardList.Add(new Saloon());
        }
        for (int i = 0; i < nbGatling; i++)
        {
            cardList.Add(new Gatling());
        }
        for (int i = 0; i < nbPlanque; i++)
        {
            cardList.Add(new Planque());
        }
        for (int i = 0; i < nbLunette; i++)
        {
            cardList.Add(new Lunette());
        }
        for (int i = 0; i < nbMustang; i++)
        {
            cardList.Add(new Mustang());
        }
        /*for (int i = 0; i < nbPrison; i++)
        {
            cardList.Add(new Prison());
        }*/
       /* for (int i = 0; i < nbDynamite; i++)
        {
            cardList.Add(new Dynamite());
        }*/
        for (int i = 0; i < nbCarabine; i++)
        {
            cardList.Add(new Carabine());
        }
        for (int i = 0; i < nbRemington; i++)
        {
            cardList.Add(new Remington());
        }
        for (int i = 0; i < nbWinchester; i++)
        {
            cardList.Add(new Winchester());
        }
        for (int i = 0; i < nbSchofield; i++)
        {
            cardList.Add(new Schofield());
        }
        /*for (int i = 0; i < nbVolcanic; i++)
        {
            cardList.Add(new Volcanic());
        }*/

    }

    /// <summary>
    /// Renvoi la Carte n° i de la liste
    /// </summary>
    /// <param name="i">Numero de carte demandé</param>
    /// <returns></returns>
    public Card getCard(int i)
    {
        return cardList[i];
    }
}
