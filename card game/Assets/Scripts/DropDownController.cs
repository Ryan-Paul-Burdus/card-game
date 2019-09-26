using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Dropdown))]
[DisallowMultipleComponent]
public class DropDownController : MonoBehaviour, IPointerClickHandler
{
    public GameObject DeckManager;
    public Text dropdownItem0;

    [Tooltip("Indexes that should be ignored. Indexes are 0 based.")]
    public List<int> indexesToDisable = new List<int>();

    private Dropdown _dropdown;

    private void Start()
    {
        DeckManager = GameObject.FindGameObjectWithTag("DeckManager");
        var savedDecksScriptArray = DeckManager.GetComponent<SavedDecks>().decks;

        for (int i = 0; i < savedDecksScriptArray.Length; i++)
        {
            if (savedDecksScriptArray[i].name == "")
            {
                indexesToDisable.Add(i);
            }
        }
    }

    private void Awake()
    {
        _dropdown = GetComponent<Dropdown>();
    }

    private void OnEnable()
    {
        StartCoroutine(loadDeckNames());
    }

    IEnumerator loadDeckNames()
    {
        yield return new WaitForSeconds(0.01f);
        DeckManager = GameObject.FindGameObjectWithTag("DeckManager");
        var savedDecksScriptArray = DeckManager.GetComponent<SavedDecks>().decks;

        if (savedDecksScriptArray[0].name == "")
        {
            dropdownItem0.text = "Empty";
        }
        else
        {
            dropdownItem0.text = savedDecksScriptArray[0].name;
        }

        for (int i = 0; i < savedDecksScriptArray.Length; i++)
        {
            if (savedDecksScriptArray[i].name == "")
            {
                _dropdown.options[i].text = "Empty";
            }
            else
            {
                _dropdown.options[i].text = savedDecksScriptArray[i].name;
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        var dropDownList = GetComponentInChildren<Canvas>();
        if (!dropDownList) return;

        // If the dropdown was opened find the options toggles
        var toogles = dropDownList.GetComponentsInChildren<Toggle>(true);
        
        for (var i = 1; i < toogles.Length; i++)
        {
            toogles[i].interactable = !indexesToDisable.Contains(i - 1);
        }
    }
    
    public void EnableOption(int index, bool enable)
    {
        if (index < 1 || index > _dropdown.options.Count)
        {
            Debug.LogWarning("Index out of range -> ignored!", this);
            return;
        }

        if (enable)
        {
            // remove index from disabled list
            if (indexesToDisable.Contains(index)) indexesToDisable.Remove(index);
        }
        else
        {
            // add index to disabled list
            if (!indexesToDisable.Contains(index)) indexesToDisable.Add(index);
        }

        var dropDownList = GetComponentInChildren<Canvas>();
        // If this returns null than the Dropdown was closed
        if (!dropDownList) return;

        // If the dropdown was opened find the options toggles
        var toogles = dropDownList.GetComponentsInChildren<Toggle>(true);
        toogles[index].interactable = enable;

    }
    
    public void EnableOption(string label, bool enable)
    {
        var index = _dropdown.options.FindIndex(o => string.Equals(o.text, label));
        
        EnableOption(index + 1, enable);
    }
}
