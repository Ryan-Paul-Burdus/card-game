using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CardDisplay : MonoBehaviour
{
    public Card card;

    public Text nameText;
    public Text descriptionText;

    public Image cardArtImage;

    public Text manaText;
    public Text attackText;
    public Text healthText;

    public Image rarityImage;

    void Update()
    {
        nameText.text = card.name;
        descriptionText.text = card.description;

        cardArtImage.sprite = card.cardImage;

        manaText.text = card.manaCost.ToString();
        attackText.text = card.attackDamage.ToString();
        healthText.text = card.health.ToString();

        rarityImage.sprite = card.rarity;
    }
}
