using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{
    public new string name;
    public string description;

    public Sprite cardImage;

    public int manaCost;
    public int attackDamage;
    public int health;

    public Sprite rarity; 
}
