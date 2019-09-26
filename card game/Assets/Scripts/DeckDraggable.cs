using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DeckDraggable : MonoBehaviour, IPointerClickHandler
{
    public GameObject deckBuilderManager;


    private void Awake()
    {
        deckBuilderManager = GameObject.FindGameObjectWithTag("DeckBuilderManager");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Destroy(gameObject);
        deckBuilderManager.GetComponent<DeckHolder>().RemoveCard();
    }
}
