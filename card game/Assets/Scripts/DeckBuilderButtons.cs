using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeckBuilderButtons : MonoBehaviour
{
    public Text nameText;
    public Text defaultNameText;
    public GameObject DeckManager;
    public GameObject deckContentArea;
    public GameObject deckCard;
    public Text deckCardAmount;
    public GameObject deckBuilderManager;

    private int currentDeckNumber;
    private GameObject draggedCardToDeck;

    private void OnEnable()
    {
        DeckManager = GameObject.FindGameObjectWithTag("DeckManager");

        //gets the array of decks
        var savedDecksScriptArray = DeckManager.GetComponent<SavedDecks>().decks;

        //have the name and contents of the deck updated each time loaded
        currentDeckNumber = SavedDecks.Instance.DeckNumber;
        var currentDeck = savedDecksScriptArray[currentDeckNumber-1];

        defaultNameText.text = currentDeck.name;

        for (int i = 0; i < currentDeck.cards.Count; i++)
        {
            //deckContentArea.transform.GetChild(i).GetComponent<DeckCardDisplay>().card = currentDeck.cards[i];

            if (currentDeck.cards[i])
            {
                draggedCardToDeck = Instantiate(deckCard);
                draggedCardToDeck.transform.SetParent(deckContentArea.transform, true);
                draggedCardToDeck.transform.localScale = deckContentArea.transform.localScale;
                draggedCardToDeck.GetComponent<DeckCardDisplay>().card = currentDeck.cards[i];
            }
        }
        DeckHolder deckHolderScript = deckBuilderManager.GetComponent<DeckHolder>();
        deckHolderScript.cardAmount = deckContentArea.transform.childCount;
        deckCardAmount.text = deckContentArea.transform.childCount + "/30";
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void SaveDeck()
    {
        //gets the array of decks
        var savedDecksScriptArray = DeckManager.GetComponent<SavedDecks>().decks;

        //checks if the deck about to be saved is full of cards and has a name
        if (deckContentArea.transform.childCount == 30 && nameText.text != null)
        {
            //changes the name of the deck array name slot to the new deck name 
            var currentDeck = savedDecksScriptArray[currentDeckNumber-1];
            currentDeck.name = nameText.text;

            //fills the deck array cards slot of the new deck cards
            for (int i = 0; i < currentDeck.cards.Count; i++)
            {
                currentDeck.cards[i] = deckContentArea.transform.GetChild(i).GetComponent<DeckCardDisplay>().card;
            }

            SaveSystem.SaveDeck(currentDeck, currentDeckNumber);//saves the current deck with the current data
        }
        else
        {
            //nothing happens because deck isnt full or there is no name for the deck

            //maybe have something happen to show the player
        }
    }
}
