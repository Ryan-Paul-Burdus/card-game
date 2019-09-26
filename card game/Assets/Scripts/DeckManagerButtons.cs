using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeckManagerButtons : MonoBehaviour
{
    public GameObject DeckManager;

    [SerializeField] List<Text> nameTextList;
    [SerializeField] List<GameObject> addButtons;
    [SerializeField] List<GameObject> editButtons;

    private void Start()
    {
        UpdateDeckBuilder();
    }

    private void OnEnable()
    {
        UpdateDeckBuilder();
    }

    public void UpdateDeckBuilder()
    {
        DeckManager = GameObject.FindGameObjectWithTag("DeckManager");
        var savedDecksScriptArray = DeckManager.GetComponent<SavedDecks>().decks;
        for (int i = 0; i < savedDecksScriptArray.Length; i++)
        {
            if (savedDecksScriptArray[i].name != "")
            {
                nameTextList[i].text = savedDecksScriptArray[i].name;
                addButtons[i].SetActive(false);
                editButtons[i].SetActive(true);
            }
            else
            {
                addButtons[i].SetActive(true);
                editButtons[i].SetActive(false);
            }
        }
    }

    public void AddOrEditDeck(int deckNumber)
    {
        SavedDecks.Instance.DeckNumber = deckNumber;
        if (DeckManager.GetComponent<SavedDecks>().decks[deckNumber-1].name != "")
        {
            DeckManager.GetComponent<SavedDecks>().deckMadeAlready = true;
        }
        else
        {
            DeckManager.GetComponent<SavedDecks>().deckMadeAlready = false;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void DeleteDeck(int deckNumber)
    {
        var savedDecksScriptArray = DeckManager.GetComponent<SavedDecks>().decks;
        nameTextList[deckNumber - 1].text = "Empty";
        var currentDeck = savedDecksScriptArray[deckNumber - 1];

        //have the cards be removed and set to nothing
        for (int i = 0; i < currentDeck.cards.Count; i++)
        {
            currentDeck.cards[i] = null;
        }
        
        currentDeck.name = "";//set the name to nothing

        SaveSystem.DeleteSave(deckNumber);

        DeckManager.GetComponent<SavedDecks>().deckMadeAlready = false;
        addButtons[deckNumber-1].SetActive(true);
        editButtons[deckNumber-1].SetActive(false);
    }
}

