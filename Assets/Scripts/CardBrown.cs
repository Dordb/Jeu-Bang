using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c> CardBrown </c> Creer une Carte du type Marron
/// </summary>
public class CardBrown : ThisCard
{

    public Card card;
    private static CardDraw list;

    /// <summary>
    /// Constructeur <c> CardBlue </c> récupére la liste de carte et utilise la méthode <c>SetCard()</c>
    /// </summary>
    void Start()
    {
        list = new CardDraw();
        SetCard();
    }

    /// <summary>
    /// Récupère la carte grace a son ID et utilise la méthode <c>SetCardComponent</c>
    /// </summary>
    void SetCard()
    {
        card = list.cardList[ID];
        SetCardComponent(card);
    }

    /// <summary>
    /// Definit les attributs visuel de la carte <c>card</c>
    /// </summary>
    /// <param name="card">Carte ayant les attributs voulu</param>
    void SetCardComponent(Card card)
    { 
        //set Title
        title.text = card.getCardName();

        //SetImage
        img.sprite = card.getCardImage();

        //SetDescription
        descript.text = card.getCardDescription();
    }


}
