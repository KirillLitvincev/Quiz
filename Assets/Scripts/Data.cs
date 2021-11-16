using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Data : MonoBehaviour
{
    public int columns = 3;
    public int rows = 1;
    public float cellSize = 150;
    public int indexSprite = 0;
    public GameObject prefab;

    public GameObject Prefab
    {
        get { return prefab; }
        set { prefab = value; }
    }
    public Text textWiner;
    public List<LattersData> lattersArray;
    public List<NumbersData> numbersArray;
    public List<ScriptableObjectData> objectData;
    public List<GameObject> frameArray;
    public ScriptableObjectData[] selectedValue;   
    public GameObject endMenu;
}
