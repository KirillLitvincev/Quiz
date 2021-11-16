using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Latter", fileName = "Latter")]
public class LattersData : ScriptableObject
{
    [SerializeField] private Sprite spriteLatter;
    public Sprite Sprite
    {
        get{ return spriteLatter; }
    }

    [SerializeField] private string identifier;
    public string Identifier
    {
        get { return identifier; }
    }
}
