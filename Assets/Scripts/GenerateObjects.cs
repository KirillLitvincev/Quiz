using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateObjects : MonoBehaviour
{
    private Data data;

    private void Start()
    {
        data = gameObject.GetComponent<Data>();
    }

    public void GenerationObject()
    {
        Vector3 vectorPosition = СalculationOfPosition();
        int indexFrame = 0;

        int difference = (data.columns * data.rows) - data.frameArray.Count;
        if (data.frameArray.Count < (data.columns * data.rows))
            for (int index = 0; index < difference; index++)
                data.frameArray.Add(Instantiate(data.prefab, transform));

        for (int rowsIndex = 0; rowsIndex < data.rows; rowsIndex++)
        {
            for(int columnIndex = 0; columnIndex < data.columns; columnIndex++)
            {
                data.frameArray[indexFrame].gameObject.transform.localPosition = vectorPosition;
                Filling(indexFrame);
                vectorPosition = PositionChange(1, vectorPosition);
                indexFrame++;
            }
            vectorPosition = PositionChange(0, vectorPosition);
        }

        gameObject.GetComponent<DOTweenFade>().FadeIn();
    }

    private Vector3 СalculationOfPosition()
    {
        Vector3 vector = new Vector3((data.columns - 1) * -(data.cellSize / 2), (data.rows - 1) * (data.cellSize / 2), 0);
        return vector;
    }

    private void Filling(int indexFrame)
    {
        data.frameArray[indexFrame].transform.Find("Button").GetComponent<Image>().sprite = data.selectedValue[data.indexSprite].Sprite;
        data.frameArray[indexFrame].transform.Find("Button").GetComponent<ButtonIdentifier>().identifier = data.selectedValue[data.indexSprite].Identifier;
        data.indexSprite++;
    }

    private Vector3 PositionChange(int number, Vector3 vector)
    {
        if (number == 0)
            vector = new Vector3((data.columns - 1) * -(data.cellSize / 2), vector.y - data.cellSize, vector.z);
        else
            vector = new Vector3(vector.x + data.cellSize, vector.y, vector.z);
        return vector;
    }
}
