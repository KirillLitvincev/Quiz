using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Data", fileName = "Data")]
public class ScriptableObjectData : ScriptableObject
{
    [SerializeField] private Sprite sprite;
    public Sprite Sprite
    {
        get { return sprite; }
        set { sprite = value; }
    }

    [SerializeField] private string identifier;
    public string Identifier
    {
        get { return identifier; }
        set { identifier = value; }
    }
}
