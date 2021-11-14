using UnityEngine;

[CreateAssetMenu(fileName = "NewCard", menuName= "Card")]
public class Card : ScriptableObject
{
    public string Name;
    public string Description;
    public Sprite Artwork;

    public int BonusPoints;
    public bool Discovered;

    public virtual void Use(BattleStats caster, BattleStats enemy, int roll)
    {

    }

}



