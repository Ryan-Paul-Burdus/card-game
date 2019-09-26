using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DeckCardDisplay : MonoBehaviour
{
    public Card card;

    public Image cardArtImage;

    public Text nameText;
    //public Text amountText;
    public Text manaText;

    void Start()
    {
        nameText.text = card.name;
        manaText.text = card.manaCost.ToString();

        cardArtImage.sprite = card.cardImage;
    }
}
