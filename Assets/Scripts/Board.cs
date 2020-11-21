using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>Board</c> élement visuel où le joueur peut déposer certaine carte Bleu
/// </summary>
public class Board : MonoBehaviour
{
    public List<int> id;
    public List<Card> played;
    public int nb_cards;
    // Start is called before the first frame update
    void Start()
    {
        id = new List<int>();
        played = new List<Card>();
    }

}
