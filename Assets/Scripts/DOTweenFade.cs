using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DOTweenFade : MonoBehaviour
{
    private Text text;
    private GameObject loadingImage;
    private void Start()
    {
        text = gameObject.transform.Find("Text").GetComponent<Text>();
        loadingImage = transform.parent.gameObject.transform.Find("LoadingImage").gameObject;
    }
    public void FadeOut()
    {

        text.DOFade(0, 1);
    }
    public void FadeIn()
    {
        if (PlayerPrefs.GetInt("Level") == 1)
            text.DOFade(1, 1);
    }

    public void FadeLoading(float start, float end)
    {
        var graphics = loadingImage.GetComponentsInChildren<Graphic>();
        foreach(var graphic in graphics)
        {
            var startColor = graphic.color;
            startColor.a = start;
            graphic.color = startColor;

            var endColor = graphic.color;
            endColor.a = end;
            graphic.DOColor(endColor, 1);
        }
    }
}
