using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptButton : MonoBehaviour
{
    private Data data;
    private EndGame endGame;
    
    private void Start()
    {
        data = transform.parent.gameObject.GetComponent<Data>();
        endGame = transform.parent.gameObject.GetComponent<EndGame>();
    }

    public void CheckWin()
    {
        if (gameObject.transform.Find("Button").GetComponent<ButtonIdentifier>().identifier == PlayerPrefs.GetString("Winner"))
        {
            gameObject.transform.Find("Star").gameObject.SetActive(true);
            gameObject.transform.Find("Button").gameObject.transform.DOPunchScale(new Vector3(0.3f, 0.3f, 0.3f), 1);
            if (PlayerPrefs.GetInt("Level") != 3)
                StartCoroutine(LoadLevel());
            else
                StartCoroutine(EndGame());
        }
        else
            gameObject.transform.Find("Button").transform.DOPunchPosition(new Vector3(5, 0, 0), 1);
    }

    IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(1);
        transform.parent.gameObject.GetComponent<LoadData>().Load((PlayerPrefs.GetInt("Level") + 1));
    }

    IEnumerator EndGame()
    {
        transform.parent.gameObject.GetComponent<DOTweenFade>().FadeLoading(0, 1);
        yield return new WaitForSeconds(1);
        data.endMenu.SetActive(true);
        transform.parent.gameObject.GetComponent<DOTweenFade>().FadeOut();
    }
}
