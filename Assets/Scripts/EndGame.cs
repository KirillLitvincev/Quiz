using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    private Data data;

    private void Start()
    {
        data = gameObject.GetComponent<Data>();
    }

    public void Home()
    {
        deleteObject();
        transform.gameObject.GetComponent<DOTweenFade>().FadeLoading(1, 0);
    }
        
    public void Repeat()
    {
        deleteObject();
        transform.gameObject.GetComponent<LoadData>().Load(1);
        transform.gameObject.GetComponent<DOTweenFade>().FadeLoading(1, 0);
    }

    private void deleteObject()
    {
        int frameArrayCount = data.frameArray.Count;
        for (int index = 0; index < frameArrayCount; index++)
            Destroy(data.frameArray[index]);
        data.frameArray.Clear();
    }
}
