using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Attack Card", menuName = "Attack Card")]
public class AttackCard : ScriptableObject {

    public new string name;
    public string description;
    public Sprite artwork;
    public int staminaCost;
    public int attack;

}
