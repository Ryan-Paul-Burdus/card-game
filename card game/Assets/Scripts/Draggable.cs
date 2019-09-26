using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject dragCard;
    public GameObject canvas;
    public RectTransform deckContainer;
    public GameObject deckContentArea;
    public GameObject deckCard;

    private GameObject currentDragCard;
    private GameObject draggedCardToDeck;

    public GameObject DeckBuilderManager;

    public void OnBeginDrag(PointerEventData eventData)
    {
        currentDragCard = Instantiate(dragCard, Input.mousePosition, Quaternion.identity);
        currentDragCard.transform.SetParent(canvas.transform, true);
        currentDragCard.transform.localScale = transform.localScale;
        currentDragCard.GetComponent<CardDisplay>().card = GetComponent<CardDisplay>().card;
    }

    public void OnDrag(PointerEventData eventData)
    {
        currentDragCard.transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        int deckCardAmount = DeckBuilderManager.GetComponent<DeckHolder>().cardAmount;

        if (rectOverlaps(deckContainer, currentDragCard.GetComponent<RectTransform>()) && deckCardAmount < 30)
        {
            //make the deck container create a deck card with the dragged cards info
            draggedCardToDeck = Instantiate(deckCard);
            draggedCardToDeck.transform.SetParent(deckContentArea.transform, true);
            draggedCardToDeck.transform.localScale = deckContentArea.transform.localScale;
            draggedCardToDeck.GetComponent<DeckCardDisplay>().card = GetComponent<CardDisplay>().card;

            DeckBuilderManager.GetComponent<DeckHolder>().AddCard();
        }
        Destroy(currentDragCard);
    }

    bool rectOverlaps(RectTransform rectTrans1, RectTransform rectTrans2)
    {
        Rect rect1 = new Rect(rectTrans1.localPosition.x, rectTrans1.localPosition.y, rectTrans1.rect.width, rectTrans1.rect.height);
        Rect rect2 = new Rect(rectTrans2.localPosition.x, rectTrans2.localPosition.y, rectTrans2.rect.width, rectTrans2.rect.height);

        return rect1.Overlaps(rect2);
    }
}
