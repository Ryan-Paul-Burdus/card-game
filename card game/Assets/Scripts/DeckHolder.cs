using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckHolder : MonoBehaviour
{
    public Text deckCardAmount;
    public int cardAmount = 0;

    public GameObject DeckManager;

    private void Awake()
    {
        DeckManager = GameObject.FindGameObjectWithTag("DeckManager");
        var savedDecksScript = DeckManager.GetComponent<SavedDecks>();
        if (savedDecksScript.deckMadeAlready)
        {
            cardAmount = 30;
        }
        else
        {
            cardAmount = 0;
        }
        deckCardAmount.text = cardAmount + "/30";
    }

    public void AddCard()
    {
        cardAmount++;
        deckCardAmount.text = cardAmount + "/30";
    }

    public void RemoveCard()
    {
        cardAmount--;
        deckCardAmount.text = cardAmount + "/30";
    }
}
