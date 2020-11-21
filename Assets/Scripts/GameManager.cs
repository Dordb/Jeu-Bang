using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using System.Threading;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;
    public GameObject CardBlue;
    public GameObject CardBrown;
    public List<GameObject> Personnages;
    public GameObject SherifStar;
    public GameObject Outlaws;
    public GameObject Deputy;

    public GameObject Message;
    public GameObject Chat;



    public int nbSheriff;
    public int nbHorsLaLoi;

    // Personnage courant (celui a qui c'est le tour)
    public GameObject currentPersonnage;
    public GameObject previousPersonnage;
    public static int cur;

    // Liste des cartes dans la pioche
    public static List<int> draw;

    // Nombre de cartes dans le jeu
    public int nb_cards;

    // Liste de toutes les cartes disponibles dans le jeu
    public static CardDraw allCards;

    // Liste des roles
    public static List<int> roles;

    // Liste des cartes dans la defausse
    public static List<int> discard = new List<int>();




    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
       //DontDestroyOnLoad(gameObject);

        InitGame();

    }

    public void InitGame()
    {
        draw = new List<int>();
        allCards = new CardDraw();
        nb_cards = allCards.cardList.Count;
        discard = new List<int>();

        nbSheriff = 1;
        nbHorsLaLoi = 3;

        CreateDraw();
        CreateRoles();


    }

    private void Start()
    {
        AssignRoles();

        Debug.developerConsoleVisible = true;

        // Distribution des cartes de départ en commencant par le sheriff
        int posDraw = roles.IndexOf(0);
        for (int i = 0; i < roles.Count; i++)
        {
            currentPersonnage = Personnages[posDraw];

            DrawCard(currentPersonnage.GetComponent<ThisPersonnage>().GetPersonnage().GetHealthMax());

            posDraw = (posDraw + 1) % roles.Count;
        }

        // Le Sheriff Commence à jouer
        cur = posDraw ;
        currentPersonnage = Personnages[cur];

        GameObject.Find("EndTurn").GetComponent<Button>().interactable = false;

        Invoke("Turn", 1);


    }

    private void Update()
    {

        if (Input.GetKeyDown("d"))
        {
            DrawCard(1);
        }

        if(nbSheriff == 0)
        {
            In_game_Menu EndMenu = (In_game_Menu) GameObject.Find("MenuManager").GetComponent(typeof(In_game_Menu));
            EndMenu.endGame("Les Hors la Loi ont gagne");
            Time.timeScale = 0;

        }

        if (nbHorsLaLoi == 0)
        {
            In_game_Menu EndMenu = (In_game_Menu)GameObject.Find("MenuManager").GetComponent(typeof(In_game_Menu));
            EndMenu.endGame("Le Sheriff et ses Adjoints ont gagne");
            Time.timeScale = 0;

        }
    }



    public int GetCur()
    {
        return cur;
    }

    public void SetCur(int x)
    {
        cur = x;
    }


    public void addMessage(String P, String A)
    {
        GameObject newMessage = Instantiate(Message, new Vector3(0, 0, 0), Quaternion.identity);
        newMessage.transform.SetParent(Chat.transform.Find("Content"), false);
        newMessage.transform.Find("Personnage").GetComponent<Text>().text = P;
        newMessage.transform.Find("Action").GetComponent<Text>().text = A;
        newMessage.tag = "Message";

    }



    /***********************************************************************************************************************************************
     *                                                                  DEBUT GESTION DES BOTS
     ***********************************************************************************************************************************************/

    // le bot souhaite joeur un Bang
    void PlayBangBot(string role, List<int>playedThisTurn, int i)
    {
        // C'est un hors la loi
        if (role == "Hors La Loi")
        {
            for (int k = 1; k < Personnages.Count; k++)
            {
                Personnage target = Personnages[(cur + k) % Personnages.Count].GetComponent<ThisPersonnage>().GetPersonnage();

                // La cible est valide
                if ((target.GetRole() == "Sheriff" && CanShoot(currentPersonnage.GetComponent<ThisPersonnage>().GetPersonnage(), target)) || (target.GetRole() == "Adjoint" && CanShoot(currentPersonnage.GetComponent<ThisPersonnage>().GetPersonnage(), target)))
                {
                    Bang b = new Bang();
                    b.PlayBot(target);
                    playedThisTurn.Add(i);
                    break;
                }
            }
        }
        else if (role == "Adjoint")
        {
            for (int k = 1; k < Personnages.Count; k++)
            {
                Personnage target = Personnages[(cur + k) % Personnages.Count].GetComponent<ThisPersonnage>().GetPersonnage();

                // La cible est valide
                if ((target.GetRole() == "Hors La Loi" && CanShoot(currentPersonnage.GetComponent<ThisPersonnage>().GetPersonnage(), target)))
                {
                    Bang b = new Bang();
                    b.PlayBot(target);
                    playedThisTurn.Add(i);
                    break;
                }
            }
        }
        // C'est un Sheriff
        else if (role == "Sheriff")
        {
            for (int k = 1; k < Personnages.Count; k++)
            {
                Personnage target = Personnages[(cur + k) % Personnages.Count].GetComponent<ThisPersonnage>().GetPersonnage();

                // La cible est valide
                if ((target.GetRole() == "Hors La Loi" && CanShoot(currentPersonnage.GetComponent<ThisPersonnage>().GetPersonnage(), target)))
                {
                    Bang b = new Bang();
                    b.PlayBot(target);
                    playedThisTurn.Add(i);
                    break;
                }
            }
        }
    }

    // le bot souhaite joeur une Biere
    void PlayBiereBot(List<int> botHand, List<int> playedThisTurn, int i)
    {
        if (currentPersonnage.GetComponent<ThisPersonnage>().GetPersonnage().GetHealth() < currentPersonnage.GetComponent<ThisPersonnage>().GetPersonnage().GetHealthMax())
        {
            Biere b = new Biere();
            b.PlayBot(botHand[i]);
            playedThisTurn.Add(i);
        }
    }

    // le bot souhaite joeur une Planque
    void PlayPlanqueBot(List<int> botHand, List<int> botBoard, List<int> playedThisTurn, int i)
    {
        bool alreadyPlayed = false;
        for (int k = 0; k < botBoard.Count; k++)
        {
            if (allCards.cardList[botBoard[k]].getCardName() == "PLANQUE")
            {
                alreadyPlayed = true;
            }

        }
        if (alreadyPlayed == false)
        {
            Planque p = new Planque();
            p.PlayBot(botHand[i]);
            botBoard.Add(botHand[i]);
            playedThisTurn.Add(i);
        }
    }

    // le bot souhaite joeur un Convoi
    void PlayConvoiBot(List<int> botHand, List<int> playedThisTurn, int i)
    {
        Convoi c = new Convoi();
        c.PlayBot(botHand[i]);
        playedThisTurn.Add(i);
        Debug.Log("Joue Convoi");
    }

    // le bot souhaite joeur une Diligence
    void PlayDiligenceBot(List<int> botHand, List<int> playedThisTurn, int i)
    {
        Diligence d = new Diligence();
        d.PlayBot(botHand[i]);
        playedThisTurn.Add(i);
        Debug.Log("Joue Diligence");
    }

    // le bot souhaite joeur une Magasin
    void PlayMagasinBot(List<int> botHand, List<int> playedThisTurn, int i)
    {
        Magasin m = new Magasin();
        m.PlayBot(botHand[i]);
        playedThisTurn.Add(i);
        Debug.Log("Joue Magasin");
    }

    // le bot souhaite joeur un Indiens
    void PlayIndiensBot(List<int> botHand, List<int> playedThisTurn, int i)
    {
        Indiens l = new Indiens();
        l.PlayBot(botHand[i]);
        playedThisTurn.Add(i);
        Debug.Log("Joue Indiens");
    }

    // le bot souhaite joeur une Gatling
    void PlayGatlingBot(List<int> botHand, List<int> playedThisTurn, int i)
    {
        Gatling g = new Gatling();
        g.PlayBot(botHand[i]);
        playedThisTurn.Add(i);
        Debug.Log("Joue Gatling");
    }

    // le bot souhaite joeur un Saloon
    void PlaySaloonBot(List<int> botHand, List<int> playedThisTurn, int i)
    {
        Saloon s = new Saloon();
        s.PlayBot(botHand[i]);
        playedThisTurn.Add(i);
        Debug.Log("Joue Saloon");
    }

    // le bot souhaite joeur un Mustang
    void PlayMustangBot(List<int> botHand, List<int> botBoard, List<int> playedThisTurn, int i)
    {
        bool alreadyPlayed = false;
        for (int k = 0; k < botBoard.Count; k++)
        {
            if (allCards.cardList[botBoard[k]].getCardName() == "MUSTANG")
            {
                alreadyPlayed = true;
            }

        }
        if (alreadyPlayed == false)
        {
            Mustang m = new Mustang();
            m.PlayBot(botHand[i]);
            botBoard.Add(botHand[i]);
            playedThisTurn.Add(i);
            Debug.Log("Joue Mustang");
        }
    }

    // le bot souhaite joeur une Lunette
    void PlayLunetteBot(List<int> botHand, List<int> botBoard, List<int> playedThisTurn, int i)
    {
        bool alreadyPlayed = false;
        for (int k = 0; k < botBoard.Count; k++)
        {
            if (allCards.cardList[botBoard[k]].getCardName() == "LUNETTE")
            {
                alreadyPlayed = true;
            }

        }
        if (alreadyPlayed == false)
        {
            Lunette l = new Lunette();
            l.PlayBot(botHand[i]);
            botBoard.Add(botHand[i]);
            playedThisTurn.Add(i);
            Debug.Log("Joue Lunette");
        }
    }

    // le bot souhaite joeur une Arme
    void PlayWeaponBot(List<int> botHand, List<int> botBoard, List<int> playedThisTurn, int i)
    {
        Debug.Log("il a une arme dans la main");
        bool alreadyPlayed = false;
        // Il a deja une arme sur son board
        for (int k = 0; k < botBoard.Count; k++)
        {
            if (allCards.cardList[botBoard[k]].GetType().BaseType.Name == "Weapon")
            {
                alreadyPlayed = true;
            }

        }
        // Il n'a pas d'armes sur son board
        if (alreadyPlayed == false)
        {
            allCards.cardList[botHand[i]].PlayBot(botHand[i]);
            botBoard.Add(botHand[i]);
            playedThisTurn.Add(i);
            Debug.Log("Joue une Arme");
        }
    }

    public void TurnBot()
    {
        string role = currentPersonnage.GetComponent<ThisPersonnage>().GetPersonnage().GetRole();
        List<int> botHand = currentPersonnage.GetComponent<ThisPersonnage>().GetPersonnage().GetHand();
        List<int> botBoard = currentPersonnage.GetComponent<ThisPersonnage>().GetPersonnage().GetBoard();
        List<int> playedThisTurn = new List<int>();
        for (int i = 0; i < botHand.Count; i++)
        {
            // Il a un Bang
            if (allCards.cardList[botHand[i]].getCardName() == "BANG!")
            {
                PlayBangBot(role, playedThisTurn, i);
            }
            // Il a une Biere
            else if (allCards.cardList[botHand[i]].getCardName() == "BIERE")
            {
                PlayBiereBot(botHand, playedThisTurn, i);

            }
            // C'est une Planque
            else if (allCards.cardList[botHand[i]].getCardName() == "PLANQUE")
            {
                PlayPlanqueBot(botHand, botBoard, playedThisTurn, i);

            }
            // C'est un Convoi
            else if (allCards.cardList[botHand[i]].getCardName() == "CONVOI")
            {
                PlayConvoiBot(botHand, playedThisTurn, i);
            }
            // C'est une Diligence
            else if (allCards.cardList[botHand[i]].getCardName() == "DILIGENCE")
            {
                PlayDiligenceBot(botHand, playedThisTurn, i);
            }
            // C'est un Magasin
            else if (allCards.cardList[botHand[i]].getCardName() == "MAGASIN")
            {
                PlayMagasinBot(botHand, playedThisTurn, i);
            }
            // C'est un Indiens
            else if (allCards.cardList[botHand[i]].getCardName() == "INDIENS")
            {
                PlayIndiensBot(botHand, playedThisTurn, i);
            }
            // C'est une Gatling
            else if (allCards.cardList[botHand[i]].getCardName() == "GATLING")
            {
                PlayGatlingBot(botHand, playedThisTurn, i);
            }
            // C'est un Saloon
            else if (allCards.cardList[botHand[i]].getCardName() == "SALOON")
            {
                PlaySaloonBot(botHand, playedThisTurn, i);
            }
            // C'est un Mustang
            else if (allCards.cardList[botHand[i]].getCardName() == "MUSTANG")
            {
                PlayMustangBot(botHand, botBoard, playedThisTurn, i);
            }
            // C'est une Lunette
            else if (allCards.cardList[botHand[i]].getCardName() == "LUNETTE")
            {
                PlayLunetteBot(botHand, botBoard, playedThisTurn, i);
            }
            // C'est une Arme
            else if (allCards.cardList[botHand[i]].GetType().BaseType.Name == "Weapon")
            {
                PlayWeaponBot(botHand, botBoard, playedThisTurn, i);
            }
        }


        for (int i = playedThisTurn.Count - 1; i >= 0; i--)
        {
            discard.Add(botHand[i]);
            botHand.RemoveAt(i);
        }
    }



    /***********************************************************************************************************************************************
    *                                                                  FIN GESTION DES BOTS
    ***********************************************************************************************************************************************/









    void Turn()
    {
        Debug.Log("Tour du joueur " + cur);
        Debug.LogWarning("Tour du joueur " + cur);

        addMessage(currentPersonnage.GetComponent<ThisPersonnage>().role.text + " : ", "Debute son tour");

        //Changement couleur current player
        

        if (previousPersonnage != null)
        {
            previousPersonnage.transform.GetChild(0).GetComponent<Image>().color = new Color32(161, 120, 21,180);

        }
        currentPersonnage.transform.GetChild(0).GetComponent<Image>().color = new Color32(255, 191, 0, 225);
        previousPersonnage = currentPersonnage;


        // Debut du tour, le joueur pioche 2 cartes
        DrawCard(2);
        currentPersonnage.GetComponent<ThisPersonnage>().GetPersonnage().hasPlayedBangThisTurn = false;


        // C'est un bot
        if (currentPersonnage.GetComponent<ThisPersonnage>().isPlayer == false)
        {
            GameObject.Find("EndTurn").GetComponent<Button>().interactable = false;

            TurnBot();

            Invoke("End", 1);

        }
        else
        {
            GameObject.Find("EndTurn").GetComponent<Button>().interactable = true;
        }

    }


    // Message a afficher pour dire au joueur de combien de cartes il doit se dafausser
    public void EndToDisc(int nb)
    {
        In_game_Menu EndMenu = (In_game_Menu)GameObject.Find("MenuManager").GetComponent(typeof(In_game_Menu));
        EndMenu.infoGame("Vous devez vous defausser de " + nb + " carte(s)");
    }


    //Fin du tour (bouton)
    public void End(){
        // Fin du tour, le joueur se defausse des cartes en surnombre
        while (currentPersonnage.GetComponent<ThisPersonnage>().GetPersonnage().GetHand().Count > currentPersonnage.GetComponent<ThisPersonnage>().GetPersonnage().GetHealth())
        {
            if (currentPersonnage.GetComponent<ThisPersonnage>().isPlayer == true){
                int nbDef = currentPersonnage.GetComponent<ThisPersonnage>().GetPersonnage().GetHand().Count - currentPersonnage.GetComponent<ThisPersonnage>().GetPersonnage().GetHealth();
                EndToDisc(nbDef);
                return;
            }
            else
            {
                int toDisc = currentPersonnage.GetComponent<ThisPersonnage>().GetPersonnage().GetHand()[0];
                Disc(toDisc);
                currentPersonnage.GetComponent<ThisPersonnage>().GetPersonnage().GetHand().RemoveAt(0);
            }
        }

        addMessage("", "Fin du tour");

        cur = (cur + 1) % Personnages.Count;
        currentPersonnage = Personnages[cur];

        GameObject.Find("EndTurn").GetComponent<Button>().interactable = false;
        Invoke("Turn",2);
    }


    // Test si p1 peut tirer sur p2
    public bool CanShoot(Personnage p1, Personnage p2)
    {
        return (p1.GetShotRange() >= DistanceBetween(p1, p2)) ;
    }


    // Calcul la distance entre deux personnages
    private int DistanceBetween(Personnage p1, Personnage p2)
    {
        int pos1 = 0;
        int pos2 = 0;
        for(int i=0; i<Personnages.Count; i++)
        {
            if (Personnages[i].GetComponent<ThisPersonnage>().GetPersonnage() == p1)
            {
                pos1 = i;
            }
            if (Personnages[i].GetComponent<ThisPersonnage>().GetPersonnage() == p2)
            {
                pos2 = i;
            }
        }

        int dist = Math.Min(Math.Abs(pos1 - pos2), Personnages.Count - Math.Abs(pos1 - pos2) % Personnages.Count) - p1.GetViewDistance() + 1 + p2.GetHided();
        return dist;
    }


    // Fonction permettant de créer la pioche
    private void CreateDraw()
    {
        for(int i=0; i<nb_cards; i++)
        {
            draw.Add(i);
        }

        Shuffle(draw);
    }


    // Fonction permettant de melanger une liste d'entiers
    private void Shuffle(List<int> l)
    {
        int tmp;
        int r;
        for(int k=0; k<l.Count; k++)
        {
            r= UnityEngine.Random.Range(0, l.Count);

            tmp = l[k];
            l[k] = l[r];
            l[r] = tmp;
        }
    }


    // Fonction permettant de créer la liste des roles
    private void CreateRoles()
    {
        // Liste des roles : 0=Sheriff 1=Adjoint 2=HorsLaLoi
        roles = new List<int>() { 0, 1, 1, 2, 2, 2 };
        Shuffle(roles);
    }


    // Fonction permettant d'assigner les roles aux personnages
    private void AssignRoles()
    {
        //Assignantion des roles aux personnages
        for (int i=0; i<roles.Count; i++)
        {
            if (roles[i] == 0)
            {
                Personnages[i].GetComponent<ThisPersonnage>().SetPersonnage(new Sheriff());

                GameObject playerSherifStar = Instantiate(SherifStar, new Vector3(0, 0, 0), Quaternion.identity);
                playerSherifStar.tag = "Sheriff";
                playerSherifStar.transform.SetParent(Personnages[i].transform.Find("Role"), false);
            }
            else if (roles[i] == 1)
            {
                Personnages[i].GetComponent<ThisPersonnage>().SetPersonnage(new Adjoint());
                GameObject playerDeputy = Instantiate(Deputy, new Vector3(0, 0, 0), Quaternion.identity);
                playerDeputy.transform.SetParent(Personnages[i].transform.Find("Role"), false);
            }
            else
            {
                Personnages[i].GetComponent<ThisPersonnage>().SetPersonnage(new HorsLaLoi());
                GameObject playerOutlaws = Instantiate(Outlaws, new Vector3(0, 0, 0), Quaternion.identity);
                playerOutlaws.transform.SetParent(Personnages[i].transform.Find("Role"), false);
            }

            //Debug.Log("Personnage " + i + " créé : " + Personnages[i].GetComponent<ThisPersonnage>().GetPersonnage());

        }

        Personnages[5].GetComponent<ThisPersonnage>().isPlayer = true;
        Personnages[5].GetComponent<ThisPersonnage>().GetPersonnage().SetPlayer();
    }


    // Fonction qui permet au joueur en cours de piocher une carte
    public void DrawCard(int k)
    {
        for(int i=0; i<k; i++)
        {
            // Si la pioche n'est pas vide
            if (draw.Count != 0)
            {
                // C'est le joueur qui pioche
                if (currentPersonnage.GetComponent<ThisPersonnage>().isPlayer == true)
                {
                    // La premiere carte de la pioche est brune
                    if (allCards.cardList[draw[0]].isBlue == false)
                    {
                        // On instantie la carte dans sa main
                        GameObject playerCardBrown = Instantiate(CardBrown, new Vector3(0, 0, 0), Quaternion.identity);
                        playerCardBrown.transform.SetParent(GameObject.Find("MainPlayer1").transform, false);

                        playerCardBrown.GetComponent<CardBrown>().ID = draw[0];

                        if (allCards.cardList[draw[0]].getCardName() == "BANG!" || allCards.cardList[draw[0]].getCardName() == "BRAQUAGE"
                            || allCards.cardList[draw[0]].getCardName() == "COUP DE FOUDRE" || allCards.cardList[draw[0]].getCardName() == "DUEL")
                        {
                            playerCardBrown.tag = "Targetable";
                        }
                        else if (allCards.cardList[draw[0]].getCardName() == "RATE!")
                        {
                            playerCardBrown.tag = "Rate";
                        }
                        else
                        {
                            playerCardBrown.tag = "Card";
                        }
                    }
                    else
                    {
                        GameObject playerCardBlue = Instantiate(CardBlue, new Vector3(0, 0, 0), Quaternion.identity);
                        playerCardBlue.transform.SetParent(GameObject.Find("MainPlayer1").transform, false);
                        playerCardBlue.tag = "Card";
                        playerCardBlue.GetComponent<CardBlue>().ID = draw[0];
                    }
                }

                // On ajoute le numéro de la carte dans sa main
                currentPersonnage.GetComponent<ThisPersonnage>().GetPersonnage().AddCardToHand(draw[0]);

                // On retire la carte de la pioche
                draw.RemoveAt(0);
            }

            // La pioche est vide
            else
            {
                Shuffle(discard);
                CopyList(draw, discard);

                discard.Clear();
            }
        }
        
    }

    // Copie l2 dans l1
    private void CopyList(List<int> l1, List<int> l2)
    {
        l1.Clear();
        for(int i=0; i<l2.Count; i++)
        {
            l1.Add(l2[i]);
        }
    }


    // Ajoute un numéro de carte dans la liste de defausse
    public void Disc(int x)
    {
        discard.Add(x);
    }


    public CardDraw GetAllCards()
    {
        return allCards;
    }
}
