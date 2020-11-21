using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe <c>Weapon</c> type de carte
/// </summary>
public abstract class Weapon : Card
{
    protected int shot_range;

    public Weapon()
    {

    }

    public int GetShotRange()
    {
        return shot_range;
    }

    public override void Play()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().addMessage("", "Pose une arme");

        Personnage target;
        // On récupère le personnage cible, qui correspond au personnage assigné à la zone de drop de la carte
        target = GameObject.Find("PlayerAreaGlob").GetComponent<ThisPersonnage>().GetPersonnage(); ;

        target.SetShotRange(shot_range);
    }

    public override void PlayBot(int i)
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().addMessage("", "Pose une arme");

        GameObject player = GameObject.Find("GameManager").GetComponent<GameManager>().currentPersonnage;

        player.GetComponent<ThisBot>().addCard(i);

        player.GetComponent<ThisPersonnage>().GetPersonnage().SetShotRange(shot_range);

    }
}
