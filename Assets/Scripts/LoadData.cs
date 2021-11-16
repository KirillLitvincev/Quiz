using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadData : MonoBehaviour
{
    private Data data;
    private void Start()
    {
        data = gameObject.GetComponent<Data>();
    }

    public void Load(int level)
    {
        if (level == 1)
        {
            data.lattersArray.Clear();
            data.numbersArray.Clear();
            LattersData[] loadLattersData;
            NumbersData[] loadNumberData;

            loadLattersData = Resources.LoadAll<LattersData>("Latter");
            loadNumberData = Resources.LoadAll<NumbersData>("Number");

            for (int indexArray = 0; indexArray < loadLattersData.Length; indexArray++)
                data.lattersArray.Add(loadLattersData[indexArray]);

            for (int indexArray = 0; indexArray < loadNumberData.Length; indexArray++)
                data.numbersArray.Add(loadNumberData[indexArray]);
        }

        PlayerPrefs.SetInt("Level", level);
        gameObject.GetComponent<EditData>().Choice();
    }
}
