using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DOTweenBounce : MonoBehaviour
{
    void Start()
    {
        if (PlayerPrefs.GetInt("Level") == 1)
            transform.DOPunchScale(new Vector3(0.3f, 0.3f, 0.3f), 1);
    }
}
