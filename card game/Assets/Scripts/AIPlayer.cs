using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIPlayer : MonoBehaviour
{
    public int playersDeck;//the deck that the player is using
    public int cardsInDeck = 30;//the amount of cards in a deck
    public List<Card> cards = new List<Card>();//a list of cards the player has
    public List<Card> cardsInHand = new List<Card>();//a list of cards in the players hand

    public int health = 30;//health for the player
    public Text healthText;//UI health for the player

    public int currentMana = 1;//current mana for the player
    public int totalMana = 10;//total mana for each turn
    public GameObject[] manaImages;//an array of images for the players mana

    public int turnNumber = 0;

    public void Start()
    {
        //get the deck info for the AI player 
        // - make a list of decks for the AI player to choose from and make this choose one from random

        currentMana = turnNumber;
        UpdateMana();
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
    }

    public void UseMana(int amount)
    {
        //have the players mana decrease by a certain amount 
    }

    public void TakeDamage(int amount)
    {
        //have the player lose health by a certain amount
    }

    public void AddHealth(int amount)
    {
        //have the health increase by a certain amount
    }

    public void DrawCard(int amount)
    {
        //increase the cards in the players hand by a certain amount 
    }
}
