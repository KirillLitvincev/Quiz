using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Number", fileName ="Number")]
public class NumbersData : ScriptableObject
{
    [SerializeField] private Sprite spriteNumber;
    public Sprite Sprite
    {
        get { return spriteNumber; }
    }

    [SerializeField] private string identifier;
    public string Identifier
    {
        get { return identifier; }
    }
}
