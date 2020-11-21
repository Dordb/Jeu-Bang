using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>Bang</c> initialise les attributs des cartes Bang
/// </summary>
public class Bang : Card
{
    public Bang()
    {
        cardName = "BANG!";
        cardDescription = "Tire sur un personnage a portee de tir";
        cardImage = Resources.Load<Sprite>("Cards/ImgCard/Bang");
    }

    /// <summary>
    /// Action lorsque la carte est joué
    /// </summary>
    public override void Play()
    {
        if(GameObject.Find("GameManager").GetComponent<GameManager>().currentPersonnage.GetComponent<ThisPersonnage>().GetPersonnage().hasPlayedBangThisTurn == false)
        {
            Personnage target;
            // On récupère le personnage cible, qui correspond au personnage assigné à la zone de drop de la carte
            target = GameObject.FindGameObjectWithTag("Dragged").GetComponent<DragDrop>().getDropZone().GetComponentInParent<ThisPersonnage>().p;

            if (isMissed(target))
            {
                SoundManagerScript.PlaySound("Nope");
                GameObject.Find("GameManager").GetComponent<GameManager>().addMessage("", "Tire sur " + target.GetRole() + " : Rate!");

            }
            else
            {
                target.takeDamageHeal(-1);
                SoundManagerScript.PlaySound("Bang");
                GameObject.Find("GameManager").GetComponent<GameManager>().addMessage("", "Tire sur " + target.GetRole() + " : Touche!");

            }

            GameObject.Find("GameManager").GetComponent<GameManager>().currentPersonnage.GetComponent<ThisPersonnage>().GetPersonnage().hasPlayedBangThisTurn = true;
        }
    }

    public override void PlayBot(int x)
    {
        
    }

    public void PlayBot(Personnage target)
    {
        if (GameObject.Find("GameManager").GetComponent<GameManager>().currentPersonnage.GetComponent<ThisPersonnage>().GetPersonnage().hasPlayedBangThisTurn == false)
        {
            if (isMissed(target))
            {
                SoundManagerScript.PlaySound("Nope");
                Debug.Log("Tire sur " + target.GetRole() + " : Raté!");
                GameObject.Find("GameManager").GetComponent<GameManager>().addMessage("", "Tire sur " + target.GetRole() + " : Rate!");
            }
            else
            {
                target.takeDamageHeal(-1);
                SoundManagerScript.PlaySound("Bang");
                Debug.Log("Tire sur " + target.GetRole() + " : Touché!");
                GameObject.Find("GameManager").GetComponent<GameManager>().addMessage("", "Tire sur " + target.GetRole() + " : Touche!");
            }

            GameObject.Find("GameManager").GetComponent<GameManager>().currentPersonnage.GetComponent<ThisPersonnage>().GetPersonnage().hasPlayedBangThisTurn = true;
        }
    }

    public bool isMissed(Personnage target)
    {
        bool miss = false;

        CardDraw allcards = GameObject.Find("GameManager").GetComponent<GameManager>().GetAllCards();

        for (int i = 0; i < target.GetBoard().Count; i++)
        {
            if (allcards.cardList[target.board[i]].getCardName() == "PLANQUE" && miss != true)
            {
                int r = UnityEngine.Random.Range(0, 4);
                if (r == 1)
                {
                    miss = true;
                }
            }
        }
        if(miss == false)
        {

            for (int i = 0; i < target.hand.Count; i++)
            {
                if (allcards.cardList[target.hand[i]].getCardName() == "RATE!" && miss != true)
                {
                    miss = true;
                    GameObject.Find("GameManager").GetComponent<GameManager>().Disc(target.hand[i]);
                    target.hand.RemoveAt(i);

                    if(target.GetPlayer() == true)
                    {
                        GameObject[] cards = GameObject.FindGameObjectsWithTag("Rate");
                        GameObject.Destroy(cards[0]);
                    }
                }
            }

        }


            return miss;
    }

}
