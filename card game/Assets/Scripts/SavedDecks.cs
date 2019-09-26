using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SavedDecks : MonoBehaviour
{
    public static SavedDecks Instance;

    public int DeckNumber;//the number of the deck being used, so that other scripts can use it
    public GameObject deckManagerButtonsObject;

    public bool deckMadeAlready = false;

    public int deckSelected;

    //states what is inside each deck item
    [System.Serializable]
    public class Deck
    {
        public string name;
        public List<Card> cards;
    }
    
    public Deck[] decks;//list of decks

    private void Awake()
    {   
        //makes it so that there is only one instance of the deckManager object at all times 
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (this != Instance)
        {
            Destroy(this.gameObject);
        }

        //loads all of the decks as soon as this script is first used
        for (int i = 0; i < 5; i++)
        {
            DeckData data = SaveSystem.LoadDeck(i + 1);
            if (data != null)
            {
                decks[i].name = data.deckName;//loads the name of the deck

                var allCards = GetComponent<CardList>().cards;
                for (int j = 0; j < 30; j++)
                {
                    for (int k = 0; k < 10; k++)
                    {
                        if (data.cards[j] == allCards[k].name)
                        {
                            decks[i].cards[j] = allCards[k];
                        }
                    }
                }
            }
        }
    }
}
