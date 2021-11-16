using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditData : MonoBehaviour
{
   private Data data;

    private void Start()
    {
        data = gameObject.GetComponent<Data>();
    }

    public void Choice()
   {
        data.indexSprite = 0;
        data.objectData.Clear();

        SettingLevel();

        switch(Random.Range(0, 2))
        {
            case 0:
                if (data.lattersArray.Count < data.columns * data.rows)
                    goto case 1;
                for(int indexArray = 0; indexArray < data.lattersArray.Count; indexArray++)
                {
                    data.objectData.Add(new ScriptableObjectData());
                    data.objectData[indexArray].Sprite = data.lattersArray[indexArray].Sprite;
                    data.objectData[indexArray].Identifier = data.lattersArray[indexArray].Identifier;
                   
                }
                break;
            case 1:
                if (data.numbersArray.Count < data.columns * data.rows)
                    goto case 1;
                for (int indexArray = 0; indexArray < data.numbersArray.Count; indexArray++)
                {
                    data.objectData.Add(new ScriptableObjectData());
                    data.objectData[indexArray].Sprite = data.numbersArray[indexArray].Sprite;
                    data.objectData[indexArray].Identifier = data.numbersArray[indexArray].Identifier;
                }
                break;
        }

        SelectData();
   }

    private void SettingLevel()
    {
        int level = PlayerPrefs.GetInt("Level");
        if (level == 2 || level == 3)
            data.rows++;
        else
        {
            data.columns = 3;
            data.rows = 1;
        }
    }

    private void SelectData()
    {
        data.selectedValue = new ScriptableObjectData[data.columns * data.rows];

        for(int indexArray = 0; indexArray < (data.columns * data.rows); indexArray++)
        {
            int randNumber = Random.Range(0, data.objectData.Count);
            data.selectedValue[indexArray] = new ScriptableObjectData();
            data.selectedValue[indexArray] = data.objectData[randNumber];
            data.objectData.RemoveAt(randNumber);
        }

        Winner();
    }

    private void Winner()
    {
        string valueWinner = data.selectedValue[Random.Range(0, data.selectedValue.Length)].Identifier;

        for (int indexArray = 0; indexArray < data.lattersArray.Count; indexArray++)
            if (data.lattersArray[indexArray].Identifier == valueWinner)
                data.lattersArray.RemoveAt(indexArray);

        for (int indexArray = 0; indexArray < data.numbersArray.Count; indexArray++)
            if (data.numbersArray[indexArray].Identifier == valueWinner)
                data.numbersArray.RemoveAt(indexArray);

        PlayerPrefs.SetString("Winner", valueWinner);
        data.textWiner.text = "Find " + PlayerPrefs.GetString("Winner");
        gameObject.GetComponent<GenerateObjects>().GenerationObject();
    }
}
