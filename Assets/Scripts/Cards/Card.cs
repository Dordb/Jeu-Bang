using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe mère des Cartes
/// </summary>
public abstract class Card
{
    public bool isBlue = false;
    protected string cardName;
    protected string cardDescription;
    protected Sprite cardImage;

    /// <summary>
    /// Renvoi le nom de la carte
    /// </summary>
    /// <returns>Le nom de la Card</returns>
    public string getCardName()
    {
        return cardName;
    }
    /// <summary>
    /// Renvoi la description de la carte
    /// </summary>
    /// <returns>La description de la Card</returns>
    public string getCardDescription()
    {
        return cardDescription;
    }

    /// <summary>
    /// Renvoi l'icone de la carte
    /// </summary>
    /// <returns>Le sprite de la Card</returns>
    public Sprite getCardImage()
    {
        return cardImage;
    }

    /// <summary>
    /// Méthode abstraite de Play()
    /// utilisé lorsque la carte est joué
    /// </summary>
    public abstract void Play();

    public abstract void PlayBot(int x);


}
