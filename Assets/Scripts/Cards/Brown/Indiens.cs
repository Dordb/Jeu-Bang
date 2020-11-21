using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>Indiens</c> initialise les attributs des cartes Indiens
/// </summary>
public class Indiens : Card
{
    public Indiens()
    {
        cardName = "INDIENS";
        cardDescription = "Les autres joueurs defaussent 1 BANG! ou perdent 1 PV";
        cardImage = Resources.Load<Sprite>("Cards/ImgCard/Indiens");
    }

    /// <summary>
    /// Action lorsque la carte est joué
    /// </summary>
    public override void Play()
    {
        int nb_players = GameObject.Find("GameManager").GetComponent<GameManager>().Personnages.Count;
        SoundManagerScript.PlaySound("Indian");
        GameObject.Find("GameManager").GetComponent<GameManager>().addMessage("", "Attaque d'Indiens!");

        for (int i = 0; i < nb_players; i++)
        {
            bool isDead = false;
            bool miss = false;
            if (GameObject.Find("GameManager").GetComponent<GameManager>().currentPersonnage != GameObject.Find("GameManager").GetComponent<GameManager>().Personnages[i])
            {
                CardDraw allcards = GameObject.Find("GameManager").GetComponent<GameManager>().GetAllCards();
                List<int> player_hand = GameObject.Find("GameManager").GetComponent<GameManager>().Personnages[i].GetComponent<ThisPersonnage>().GetPersonnage().GetHand();
                for (int j = 0; j < player_hand.Count; j++)
                {
                    if (allcards.cardList[player_hand[j]].getCardName() == "BANG!" && miss !=true)
                    {
                        miss = true;
                        GameObject.Find("GameManager").GetComponent<GameManager>().Disc(player_hand[j]);
                        GameObject.Find("GameManager").GetComponent<GameManager>().Personnages[i].GetComponent<ThisPersonnage>().GetPersonnage().GetHand().RemoveAt(j);
                        if (GameObject.Find("GameManager").GetComponent<GameManager>().Personnages[i].GetComponent<ThisPersonnage>().GetPersonnage().GetPlayer() == true)
                        {
                            GameObject[] cards = GameObject.FindGameObjectsWithTag("Targetable");
                            foreach(var clone in cards)
                            {
                                if(clone.GetComponent<CardBrown>().title.text == "BANG!")
                                {
                                    GameObject.Destroy(clone);
                                    break;
                                }
                            }
                        }
                    }
                }
                
                if (miss == false)
                {
                    isDead = GameObject.Find("GameManager").GetComponent<GameManager>().Personnages[i].GetComponent<ThisPersonnage>().GetPersonnage().takeDamageHeal(-1);
                    if (isDead)
                    {
                        nb_players--;
                        i--;
                    }
                }
            }
        }
    }

    public override void PlayBot(int x)
    {
        Play();
    }
}

