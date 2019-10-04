# card-game
card game (currently being created) made in my free time at home.
This game is a singleplayer card game (plans to make multiplayer) made in Unity with C# where the main features of the game are: 
- Creating, editing and deleting card decks 
- Playing a game with an AI player with a selected card deck

The player will first need to create a deck using the deck builder and will then have to add cards and name this deck to be able to save the deck to the deck selecter. The player will then be able to pick a deck in the deck selecter and play the game against an AI player. The cards are drawn every turn and the player will win the game when the other players health reaches zero.

 All code and art used within this game have been created by myself (Ryan Burdus) and nobody else.
 
## Code Highlights

- Deck Manager buttons
```C# 
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
```

- Save System
```C#
public static void SaveDeck(SavedDecks.Deck deck, int deckNumber)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/deck" + deckNumber + ".saved";
        FileStream stream = new FileStream(path, FileMode.Create);

        DeckData data = new DeckData(deck);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static void DeleteSave(int deckNumber)
    {
        string path = Application.persistentDataPath + "/deck" + deckNumber + ".saved";
        File.Delete(path);
    }

    public static DeckData LoadDeck(int deckNumber)
    {
        string path = Application.persistentDataPath + "/deck" + deckNumber + ".saved";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            DeckData data = formatter.Deserialize(stream) as DeckData;
            stream.Close();

            return data;
        }
        else
        {
            return null;
        }
    }
```

- Saved Decks
```C#
for (int i = 0; i < 5; i++)
        {
            DeckData data = SaveSystem.LoadDeck(i + 1);
            if (data != null)
            {
                decks[i].name = data.deckName;//loads the name of the deck

                var allCards = GetComponent<CardList>().cards;
                for (int j = 0; j < 30; j++)
                {
                    for (int k = 0; k < 10; k++)
                    {
                        if (data.cards[j] == allCards[k].name)
                        {
                            decks[i].cards[j] = allCards[k];
                        }
                    }
                }
            }
        }
```

## How to run the game/program
- To run the program you will need to have Unity 2019.3.0a4 installed on your computer and to load up the project once this is finished.

- To run the game as a build you will need to build the game within Unity and run the .exe that is then downloaded from that. This is only because I am yet to makea build for this game at this time.


## Screenshots 

- Card deck editor
![alt text](https://github.com/Ryan-Paul-Burdus/card-game/blob/master/Screenshots/Deck%20editor.png "Card deck editor")

![alt text](https://github.com/Ryan-Paul-Burdus/card-game/blob/master/Screenshots/Deck%20editor%20selection.png "Edit deck selecter")

- Card deck selecter
![alt text](https://github.com/Ryan-Paul-Burdus/card-game/blob/master/Screenshots/Deck%20selection.png "Card deck selecter")

- Gameplay 
![alt text](https://github.com/Ryan-Paul-Burdus/card-game/blob/master/Screenshots/Gameplay.png "Gameplay screen")
