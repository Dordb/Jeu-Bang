using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Class <c>Personnage</c> déclare les attributs d'un Personnage
/// ainsi que les fontions permetant de modifier ses attributs
/// </summary>
public class Personnage
{
    protected string role;
    protected int health;
    protected int healthMax;

    protected int shot_range;
    protected int view_distance;
    protected int hided;

    bool isDead = false;

    public bool hasPlayedBangThisTurn = false;


    public List<int> hand;

    public List<int> board;

    protected bool isPlayer = false;

    public Personnage()
    {
        role = "";
        health = 0;
        healthMax = 0;
        hand = new List<int>();
        board = new List<int>();
        shot_range = 1;
        view_distance = 1;
        hided = 0;

    }

    public void SetPlayer()
    {
        isPlayer = true;
    }

    public bool GetPlayer()
    {
        return isPlayer;
    }


    public void SetShotRange(int x)
    {
        shot_range = x;
    }

    public void SetHided(int x)
    {
        hided = x;
    }

    public void SetViewDistance(int x)
    {
        view_distance = x;
    }


    public string GetRole()
    {
        return role;
    }

    public int GetHealth()
    {
        return health;
    }

    public int GetHealthMax()
    {
        return healthMax;
    }

    public int GetShotRange()
    {
        return shot_range;
    }

    public int GetViewDistance()
    {
        return view_distance;
    }

    public int GetHided()
    {
        return hided;
    }

    public List<int> GetHand()
    {
        return hand;
    }

    public List<int> GetBoard()
    {
        return board;
    }


    /// <summary>
    /// Méthode permettant de diminuer ou d'augmenter les points de vie du Personnage
    /// </summary>
    /// <param name="dmg">nb de points de vie a ajouter (valeur négative pour enlever)</param>
    /// /// <returns> true si tué sinon false</returns>
    public bool takeDamageHeal(int dmg)
    {
        health += dmg;
        if (health <= 0)
        {
            health = 0;
            healthMax = 0;
            for(int k=0; k<hand.Count; k++)
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().Disc(hand[k]);
            }
            hand.Clear();

            List<GameObject> Personnages = GameObject.Find("GameManager").GetComponent<GameManager>().Personnages;

            for (int i = 0; i < Personnages.Count; i++)
            {
                if (Personnages[i].GetComponent<ThisPersonnage>().GetPersonnage().GetHealth() == 0)
                {
                    if(Personnages[i].GetComponent<ThisPersonnage>().GetPersonnage().GetRole() == "Sheriff")
                    {
                        GameObject.Find("GameManager").GetComponent<GameManager>().nbSheriff--;
                        Debug.Log(GameObject.Find("GameManager").GetComponent<GameManager>().nbSheriff);
                    }
                    else if (Personnages[i].GetComponent<ThisPersonnage>().GetPersonnage().GetRole() == "Hors La Loi")
                    {
                        GameObject.Find("GameManager").GetComponent<GameManager>().nbHorsLaLoi--;
                        Debug.Log(GameObject.Find("GameManager").GetComponent<GameManager>().nbHorsLaLoi);
                    }

                    Personnages.RemoveAt(i);

                }
            }

        }
        if (health > healthMax)
        {
            health = healthMax;
        }
        if(health == 0 && !isDead)
        {
            isDead = true;
            SoundManagerScript.PlaySound("Oof");
        }

        return isDead;
    }


    public void AddCardToHand(int x)
    {
        hand.Add(x);
    }
}
