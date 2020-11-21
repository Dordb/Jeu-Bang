using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>DragDrop</c> permet le déplacement Drag and Drop des Cartes
/// </summary>
public class DragDrop : MonoBehaviour
{
    private GameObject playerMain;
    private bool dragged = false;
    private bool blueCardDropable = false;
    private bool brownCardDropable = false;
    private GameObject dropZone;
    private GameObject useZone;
    private Vector2 positionDepart;

    // Start is called before the first frame update
    void Start()
    {
        playerMain = GameObject.Find("MainPlayer1");
    }

    // Update is called once per frame
    void Update()
    {
        if (dragged)
        {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
    }


    /// <summary>
    /// Méthode appeler lors de la collision de deux éléments
    /// Celle ci permet d'autoriser ou non de déposer la carte sur certaine zone par la modification de booléen a <c>true</c>
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "PlayerArea")
        {
            if (gameObject.tag != "Targetable")
            {
                brownCardDropable = true;
            }

            blueCardDropable = true;
            dropZone = collision.gameObject;
        }
        else if (collision.gameObject.name == "BlueCardArea" && gameObject.tag == "Targetable")
        {
            brownCardDropable = true;
            dropZone = collision.gameObject;
        }
        else if(collision.gameObject.name == "Defausse")
        {
            dropZone = collision.gameObject;
        }
    }

    /// <summary>
    /// Méthode appeler lors de la sortie de collision de deux éléments
    /// Remet les booléen a <c>false</c> pour ré-interdire la placement de la carte a des postions non autorisé
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionExit2D(Collision2D collision)
    {
        blueCardDropable = false;
        brownCardDropable = false;
        dropZone = null;
    }

    /// <summary>
    /// Méthode appeler lors du début du drag de l'élément 
    /// Garde en mémoire la position de départ en cas de fin de drag sur zone non autorisé
    /// Et modifie le booléen <c>dragged</c> a true si l'élement et dans une zone ou l'on peut prendre les éléments
    /// </summary>
    public void StartDrag()
    {
        positionDepart = transform.position;

        if (transform.parent == playerMain.transform && GameObject.Find("GameManager").GetComponent<GameManager>().currentPersonnage.GetComponent<ThisPersonnage>().isPlayer == true) 
        {
            dragged = true;
        }
    }

    /// <summary>
    /// Méthode appeler lors de la fin du drag de l'élément 
    /// Définit l'action a faire en fonction de l'élément et de la zone où il est laché 
    /// Et modifie le booléen <c>dragged</c> a <c>false</c> et remet a sa place départ si la zone est non autorisé
    /// </summary>
    public void endDrag()
    {
        int del = -1;
        if (dragged == true)
        {
            // DEFAUSSE
            if (dropZone != null && dropZone.name == "Defausse")
            {
                // On ajoute la carte dans la liste de defausse du GameManager
                if (gameObject.GetComponent<CardBlue>() != null)
                {
                    GameObject.Find("GameManager").GetComponent<GameManager>().Disc(gameObject.GetComponent<CardBlue>().ID);
                    del = GameObject.Find("PlayerAreaGlob").GetComponent<ThisPersonnage>().GetPersonnage().GetHand().IndexOf(gameObject.GetComponent<CardBlue>().ID);
                }
                else
                {
                    GameObject.Find("GameManager").GetComponent<GameManager>().Disc(gameObject.GetComponent<CardBrown>().ID);
                    del = GameObject.Find("PlayerAreaGlob").GetComponent<ThisPersonnage>().GetPersonnage().GetHand().IndexOf(gameObject.GetComponent<CardBrown>().ID);
                }

                // On detruit l'instance de l'objet 
                Destroy(gameObject);
            }
            // Carte Blue pose
            else if (gameObject.name == "CardBlue(Clone)" && blueCardDropable && !AlreadyPlay(gameObject.GetComponent<CardBlue>().card))
            {
                Debug.Log("Drop");
                del = GameObject.Find("PlayerAreaGlob").GetComponent<ThisPersonnage>().GetPersonnage().GetHand().IndexOf(gameObject.GetComponent<CardBlue>().ID);
                transform.SetParent(dropZone.transform, false);
                gameObject.GetComponent<CardBlue>().card.Play();

                GameObject.Find("PlayerArea").GetComponent<Board>().played.Add(gameObject.GetComponent<CardBlue>().card);
                GameObject.Find("PlayerArea").GetComponent<Board>().id.Add(gameObject.GetComponent<CardBlue>().ID);
                GameObject.Find("PlayerAreaGlob").GetComponent<ThisPersonnage>().GetPersonnage().GetBoard().Add(gameObject.GetComponent<CardBlue>().ID);
            }
            // Carte Brown utilise
            else if (gameObject.name == "CardBrown(Clone)" && brownCardDropable && dropZone.GetComponentInParent<ThisPersonnage>().GetPersonnage().GetHealthMax() != 0)
            {
                if (GameObject.Find("GameManager").GetComponent<GameManager>().CanShoot(GameObject.Find("PlayerAreaGlob").GetComponent<ThisPersonnage>().GetPersonnage(), dropZone.GetComponentInParent<ThisPersonnage>().GetPersonnage()))
                {
                    if(gameObject.GetComponent<CardBrown>().card.GetType().Name == "Bang")
                    {
                        if (GameObject.Find("GameManager").GetComponent<GameManager>().currentPersonnage.GetComponent<ThisPersonnage>().GetPersonnage().hasPlayedBangThisTurn == false)
                        {

                            // On tag la carte pour pouvoir la recuperer lors de l'appel de fonction Play()
                            gameObject.tag = "Dragged";
                            gameObject.GetComponent<CardBrown>().card.Play();


                            //ajout Id Card dans defause
                            GameObject.Find("GameManager").GetComponent<GameManager>().Disc(gameObject.GetComponent<CardBrown>().ID);
                            del = GameObject.Find("PlayerAreaGlob").GetComponent<ThisPersonnage>().GetPersonnage().GetHand().IndexOf(gameObject.GetComponent<CardBrown>().ID);
                            //destroy card
                            Destroy(gameObject);
                        }
                        else
                        {
                            transform.position = positionDepart;
                        }
                    }
                    else
                    {
                        if (gameObject.tag == "Rate")
                        {
                            transform.position = positionDepart;
                        }
                        else
                        {
                            // On tag la carte pour pouvoir la recuperer lors de l'appel de fonction Play()
                            gameObject.tag = "Dragged";
                            gameObject.GetComponent<CardBrown>().card.Play();


                            //ajout Id Card dans defause
                            GameObject.Find("GameManager").GetComponent<GameManager>().Disc(gameObject.GetComponent<CardBrown>().ID);
                            del = GameObject.Find("PlayerAreaGlob").GetComponent<ThisPersonnage>().GetPersonnage().GetHand().IndexOf(gameObject.GetComponent<CardBrown>().ID);
                            //destroy card
                            Destroy(gameObject);
                        }
                        
                    }
                }
                else
                {
                    In_game_Menu EndMenu = (In_game_Menu)GameObject.Find("MenuManager").GetComponent(typeof(In_game_Menu));
                    EndMenu.infoGame("Cible hors de portee");
                    transform.position = positionDepart;
                }


            }
            else
            {
                transform.position = positionDepart;
            }

            if(del >= 0)
            {
                GameObject.Find("PlayerAreaGlob").GetComponent<ThisPersonnage>().GetPersonnage().GetHand().RemoveAt(del);
            }
        }

        dragged = false;
        
    }


    public GameObject getDropZone()
    {
        return dropZone;
    }


    /// <summary>
    /// Fonction qui permet de savoir si une carte du même type a déja été joué
    /// </summary>
    /// <param name="card">Card à tester</param>
    /// <returns>true si la Card a déja été joué sinon false</returns>
    public bool AlreadyPlay(Card card)
    {
        bool res = false;


        if(card.GetType().BaseType.Name == "Weapon")
        {
            for(int i=0; i< GameObject.Find("PlayerArea").GetComponent<Board>().played.Count; i++)
            {
                if(GameObject.Find("PlayerArea").GetComponent<Board>().played[i].GetType().BaseType.Name == "Weapon")
                {
                    GameObject.Find("GameManager").GetComponent<GameManager>().Disc(GameObject.Find("PlayerArea").GetComponent<Board>().id[i]);

                    Destroy(GameObject.FindGameObjectWithTag("ActiveWeapon"));

                    GameObject.Find("PlayerArea").GetComponent<Board>().id.RemoveAt(i);
                    GameObject.Find("PlayerArea").GetComponent<Board>().played.RemoveAt(i);
                }

            }
            gameObject.tag = "ActiveWeapon";
        }



        else
        {
            for (int i = 0; i < GameObject.Find("PlayerArea").GetComponent<Board>().played.Count; i++)
            {
                if (GameObject.Find("PlayerArea").GetComponent<Board>().played[i].getCardName() == card.getCardName())
                {
                    res = true;
                }
            }
        }

        return res;
    }
    
}
