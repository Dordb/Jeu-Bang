using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// Affichage des informations des bots
public class ThisBot : ThisPersonnage
{
    public Text nbCard;

    public GameObject CardBlue;

    private void Update()
    {
        health.text = p.GetHealth().ToString();
        healthMax.text = p.GetHealthMax().ToString();
        role.text = p.GetRole();
        hand = p.GetHand();
        nbCard.text = p.GetHand().Count.ToString() + " Carte(s) en main";

        if (health.text == "0")
        {
            Debug.Log("MORT");
            var toDel = GameObject.FindGameObjectsWithTag(id);
            Debug.Log(toDel);
            foreach (var del in toDel)
            {
                Debug.Log(del);
                Destroy(del);
            }
        }
    }

    public void addCard(int i)
    {
        GameObject playerCard = Instantiate(CardBlue, new Vector3(0, 0, 0), Quaternion.identity);
        playerCard.transform.SetParent(board.transform, false);

        playerCard.tag = id;

        playerCard.GetComponent<CardBlue>().ID = i;
    }

}
