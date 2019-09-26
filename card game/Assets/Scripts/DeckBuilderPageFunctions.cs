using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckBuilderPageFunctions : MonoBehaviour
{
    public int pageNumber = 1;
    public Text pageText;

    private int currentDeckNumber;

    [SerializeField] List<GameObject> cardLocations;
    [SerializeField] List<GameObject> cardLocationVisibility;
    [SerializeField] List<Card> cards;

    private int j = 10;

    private void OnEnable()
    {
        pageText.text = "Page " + pageNumber + "/4";
        j = 10;
    }

    void Update()
    {
        if (pageNumber == 1)
        {
            j = 10;
            for (int i = 0; i < cardLocations.Count; i++)
            {
                cardLocations[i].GetComponent<CardDisplay>().card = cards[i];
                cardLocationVisibility[i].SetActive(true);
            }
        }
        if (pageNumber == 2)
        {
            j = 10;
            for (int i = 0; i < cardLocations.Count; i++)
            {
                if (cards[j] != null)
                {
                    cardLocations[i].GetComponent<CardDisplay>().card = cards[j];
                    cardLocationVisibility[i].SetActive(true);
                }
                else
                {
                    cardLocationVisibility[i].SetActive(false);
                }
                j++;
            }
        }
        if (pageNumber == 3)
        {
            j = 20;
            for (int i = 0; i < cardLocations.Count; i++)
            {
                if (cards[j] != null)
                {
                    cardLocations[i].GetComponent<CardDisplay>().card = cards[j];
                    cardLocationVisibility[i].SetActive(true);
                }
                else
                {
                    cardLocationVisibility[i].SetActive(false);
                }
                j++;
            }
        }
        if (pageNumber == 4)
        {
            j = 30;
            for (int i = 0; i < cardLocations.Count; i++)
            {
                if (cards[j] != null)
                {
                    cardLocations[i].GetComponent<CardDisplay>().card = cards[j];
                    cardLocationVisibility[i].SetActive(true);
                }
                else
                {
                    cardLocationVisibility[i].SetActive(false);
                }
                j++;
            }
        }
    }

    public void PageNumberUp()
    {
        if (pageNumber < 4 && j < cards.Count)
        {
            pageNumber++;
            pageText.text = "Page " + pageNumber + "/4";
        }
    }

    public void PageNumberDown()
    {
        if (pageNumber > 1)
        {
            pageNumber--;
            pageText.text = "Page " + pageNumber + "/4";
        }
    }
}
