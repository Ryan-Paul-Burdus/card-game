using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
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
}
