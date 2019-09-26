using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject DeckManager;
    public Text dropdownText;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void DeckSelected()
    {
        DeckManager = GameObject.FindGameObjectWithTag("DeckManager");
        string dropDownString = dropdownText.text;
        if (dropDownString == "Deck 1")
        {
            DeckManager.GetComponent<SavedDecks>().deckSelected = 1;
        }
        if (dropDownString == "Deck 2")
        {
            DeckManager.GetComponent<SavedDecks>().deckSelected = 2;
        }
        if (dropDownString == "Deck 3")
        {
            DeckManager.GetComponent<SavedDecks>().deckSelected = 3;
        }
        if (dropDownString == "Deck 4")
        {
            DeckManager.GetComponent<SavedDecks>().deckSelected = 4;
        }
        if (dropDownString == "Deck 5")
        {
            DeckManager.GetComponent<SavedDecks>().deckSelected = 5;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
