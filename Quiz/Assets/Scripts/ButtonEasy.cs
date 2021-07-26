using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ButtonEasy : MonoBehaviour
{
    public Easy easyRef;
    public GameObject star;
    public Image field;
    public int num;

    void OnMouseDown()
    {
        if (easyRef.final[num].name == easyRef.obj)
        {
            easyRef.final[num].transform.DOShakePosition(1f, strength: new Vector3(0, 2, 0), vibrato: 5, randomness: 1, snapping: false, fadeOut: true);
            StartCoroutine(Stars());
        }
        else
        {
            easyRef.final[num].transform.DOShakePosition(1f, strength: new Vector3(2, 0, 0), vibrato: 5, randomness: 1, snapping: false, fadeOut: true);
        }
    }

    IEnumerator Stars()
    {
        for (int i = 0; i < 10; i++)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), Camera.main.farClipPlane / 10));
            Instantiate(star, pos, Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(0.9f);
        field.DOFade(1.0f, 0.5f);
        yield return new WaitForSeconds(0.5f);
        Application.LoadLevel("Level2");
    }
}
