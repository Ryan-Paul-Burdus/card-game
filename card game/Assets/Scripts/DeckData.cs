using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DeckData
{
    public string deckName;//name of deck
    public string[] cards;//cards in the deck

    public DeckData(SavedDecks.Deck deck)
    {
        deckName = deck.name;
        cards = new string[30];
        for (int i = 0; i < 30; i++)
        {
            cards[i] = deck.cards[i].name;
        }
    }
}
