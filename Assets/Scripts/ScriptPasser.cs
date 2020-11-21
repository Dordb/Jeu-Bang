/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScriptPasser : MonoBehaviour
{
    public GameObject CardBlue;
    public GameObject CardBrown;
    public GameObject PlayerMain;
    public GameObject PlayerArea;
    public GameObject[] BotArea;
    public GameObject SherifStar;
    private GameObject blueCardArea;
    public static bool isSherif = false;

    public static List<int> cardList = new List<int>();

    public int nb_cards;

    private static CardDraw available;

    public static List<int> roles = new List<int>();

    public static List<int> defausse = new List<int>();

    public void Def(int x)
    {
        defausse.Add(x);
    }

    private void Start()
    {
        available = new CardDraw();
        nb_cards = available.cardList.Count;

        createDraw();

    }


    public void createRoles()
    {
        if (!isSherif)
        {
            isSherif = true;

        roles.Add(0);
        roles.Add(1);
        roles.Add(1);
        roles.Add(2);
        roles.Add(2);
        roles.Add(2);

        Shuffle(roles);

        //Debug.Log("taille de roles " + roles.Count);

        for (int i = 0; i < roles.Count; i++)
        {
            if (roles[i] == 0)
            {
                GameObject playerSherifStar = Instantiate(SherifStar, new Vector3(0, 0, 0), Quaternion.identity);
                playerSherifStar.tag = "Sheriff";
                if (i != 5)
                {
                    playerSherifStar.transform.SetParent(BotArea[i].transform.Find("Role"), false);
                    BotArea[i].GetComponent<ThisPersonnage>().p = new Sheriff();
                }
                else
                {
                    playerSherifStar.transform.SetParent(PlayerArea.transform.Find("Role"), false);
                    PlayerArea.GetComponent<ThisPersonnage>().p = new Sheriff();
                }
            }
            else if (roles[i] == 1)
            {
                if (i != 5)
                {
                    BotArea[i].GetComponent<ThisPersonnage>().p = new Adjoint();
                }
                else
                {
                    PlayerArea.GetComponent<ThisPersonnage>().p = new Adjoint();
                }
            }
            else
            {
                if (i != 5)
                {
                    BotArea[i].GetComponent<ThisPersonnage>().p = new HorsLaLoi();
                }
                else
                {
                    PlayerArea.GetComponent<ThisPersonnage>().p = new HorsLaLoi();
                }
            }
        }

        for(int i=0; i<roles.Count; i++)
            {
                if(i != 5)
                {
                    BotArea[i].GetComponent<ThisPersonnage>().ChangeAttribut();
                }
                else
                {
                    PlayerArea.GetComponent<ThisPersonnage>().ChangeAttribut();
                }
            }
        }
    }

    public void createDraw()
    {
        //Debug.Log("creation de la pioche");
        cardList.Clear();

        for (int i = 0; i < nb_cards; i++)
        {
            cardList.Add(i);
        }

        Shuffle(cardList);

    }

    public void Shuffle(List<int> l)
    {
        for (int j = 0; j < l.Count; j++)
        {
            int k = Random.Range(0, l.Count);

            int tmp = l[j];
            l[j] = l[k];
            l[k] = tmp;
        }
    }

    public void createCard()
    {
        

        for (int i = 0; i < 4; i++)
        {
            if(cardList.Count != 0)
            {
                if(available.cardList[cardList[0]].isBlue == false)
                //if(cardList[0] < 63)
                {
                    GameObject playerCardBrown = Instantiate(CardBrown, new Vector3(0, 0, 0), Quaternion.identity);
                    playerCardBrown.transform.SetParent(PlayerMain.transform, false);
                    playerCardBrown.tag = "Card";
                    playerCardBrown.GetComponent<CardBrown>().ID = cardList[0];
                }
                else
                {
                    GameObject playerCardBlue = Instantiate(CardBlue, new Vector3(0, 0, 0), Quaternion.identity);
                    playerCardBlue.transform.SetParent(PlayerMain.transform, false);
                    playerCardBlue.tag = "Card";
                    playerCardBlue.GetComponent<CardBlue>().ID = cardList[0];
                }
                cardList.RemoveAt(0);
            }
            else
            {
                Shuffle(defausse);
                cardList = defausse;

                defausse.Clear();
            }

        }

    }

    public void destroyCard()
    {
        var clones = GameObject.FindGameObjectsWithTag("Card");
        foreach (var clone in clones) 
        {
            Destroy(clone); 
        }
        isSherif = false;

        cardList.Clear();
        createDraw();

        GameObject.Find("PlayerArea").GetComponent<Board>().played.Clear();

        var star = GameObject.FindGameObjectsWithTag("Sheriff");
        foreach (var clone in star)
        {
            Destroy(clone);
        }
        roles.Clear();

    }


}
*/