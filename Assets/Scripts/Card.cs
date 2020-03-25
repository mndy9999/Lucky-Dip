using UnityEngine;

[CreateAssetMenu(fileName = "NewCard", menuName= "Card")]
public class Card : ScriptableObject
{
    public string Name;
    public string Description;
    public Sprite Artwork;

    public int RollLow;
    public int RollMed;
    public int RollHigh;

    public GameObject Enemy;

    public CardTypes CardType;
}

public enum CardTypes { Unknown, Attack, Ability, Healing, RideOrDie, SkipTurn, LeaveBattle, DoubleDamage, DoubleHealth };

// Define an extension method in a non-nested static class.
public static class Extensions
{
    public static bool IsEnemyCard(this CardTypes type)
    {
        switch (type)
        {
            case CardTypes.Attack:
            case CardTypes.Ability:
            case CardTypes.Healing:
            case CardTypes.RideOrDie:
                return true;
            default:
                return false;
        }
}
    }


