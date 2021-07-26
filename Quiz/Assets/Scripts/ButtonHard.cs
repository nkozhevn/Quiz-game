using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ButtonHard : MonoBehaviour
{
    public Hard hardRef;
    public GameObject star, restart;
    public Image darkness;
    public int num;
    public RawImage[] buttons = new RawImage[9];

    void OnMouseDown()
    {
        if (hardRef.final[num].name == hardRef.obj)
        {
            hardRef.final[num].transform.DOShakePosition(1f, strength: new Vector3(0, 2, 0), vibrato: 5, randomness: 1, snapping: false, fadeOut: true);
            StartCoroutine(Stars());
        }
        else
        {
            hardRef.final[num].transform.DOShakePosition(1f, strength: new Vector3(2, 0, 0), vibrato: 5, randomness: 1, snapping: false, fadeOut: true);
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

        foreach(var button in buttons)
        {
            button.transform.Translate(100, 0, 0);
        }

        darkness.DOFade(0.3f, 0.5f);
        yield return new WaitForSeconds(0.5f);

        restart.SetActive(true);
    }
}

