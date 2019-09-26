using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject deckManager;

    public int playersDeck;//the deck that the player is using
    public int cardsInDeck = 30;//the amount of cards in a deck
    public List<Card> cards = new List<Card>();//a list of cards the player has
    public List<Card> cardsInHand = new List<Card>();//a list of cards in the players hand

    public int health = 30;//health for the player
    public Text healthText;//UI health for the player

    public int currentMana;//current mana for the player
    public int totalMana = 10;//total mana for each turn
    public GameObject[] manaImages;//an array of images for the players mana

    public int turnNumber = 0;

    public void Start()
    {
        deckManager = GameObject.FindGameObjectWithTag("DeckManager");
        var savedDeckScript = deckManager.GetComponent<SavedDecks>();

        playersDeck = savedDeckScript.deckSelected;//sets the players deck to the selected deck

        //sets the cards so that the players deckmatches the selected deck
        var currentDeck = savedDeckScript.decks[playersDeck];
        for (int i = 0; i < 30; i++)
        {
            cards[i] = currentDeck.cards[i];
        }

        currentMana = turnNumber;
        UpdateMana();//sets the mana at the start of the game
    }

    public void IncrementTurnNo()
    {
        if (turnNumber < 10)
        {
            turnNumber++;
        }
        currentMana = turnNumber;
        UpdateMana();
    }

    public void UpdateMana()
    {
        //sets mana to show the correct mana for when called
        for (int i = 0; i < currentMana; i++)
        {
            manaImages[i].SetActive(true);
        }
        for (int i = currentMana; i < 10; i++)
        {
            manaImages[i].SetActive(false);
        }
    }

    public void AddMana(int amount)
    {
        //have the mana increase by a certain amount
        currentMana += amount;
        if (currentMana > 10)
        {
            currentMana = 10;
        }
        UpdateMana();
    }

    public void UseMana(int amount)
    {
        //have the players mana decrease by a certain amount 
        currentMana -= amount;
        if (currentMana < 0)
        {
            currentMana = 0;
        }
        UpdateMana();
    }

    public void TakeDamage(int amount)
    {
        //has the player lose health by a certain amount
        health -= amount;
        healthText.text = health.ToString();
        if (health <= 0)
        {
            GameOver();//dead
        }
    }

    public void AddHealth(int amount)
    {
        //has the health increase by a certain amount
        health += amount;
        healthText.text = health.ToString();
    }

    public void DrawCard(int amount)
    {
        //increase the cards in the players hand by a certain amount 
    }

    public void GameOver()
    {
        //have the game do something when the game is over
    }
}
