using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TargetingOptions
{
    NoTarget,
    AllCreatures,
    EnemyCreatures,
    YourCreatures
}

[CreateAssetMenu]
public class CardAsset : ScriptableObject
{
    [Header("General info")]
    public CharacterAsset characterAsset;
    [TextArea(2, 3)]
    public string Description;
    public Sprite CardImage;
    public int ManaCost;

    [Header("Creatuer Info")]
    public int MaxHealth;
    public int Attack;
    public int AttackForOneTurn = 1;
    public bool Charge;
    public string CreatureScriptName;
    public int specialCreatureAmount;

    [Header("SpellInfo")]
    public string SpellScriptName;
    public int specialSpellAmount;
    public TargetingOptions Targets;
}
