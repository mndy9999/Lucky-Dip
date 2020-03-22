using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCard", menuName = "Card")]
public class Card : ScriptableObject
{
    public string Name;
    public string Description;
    public Sprite Artwork;

    public int RollLow;
    public int RollMed;
    public int RollHigh;

    public CardTypes CardType;

    public enum CardTypes { Attack, Ability, Healing, RideOrDie};
}
