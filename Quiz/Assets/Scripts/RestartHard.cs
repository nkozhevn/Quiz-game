using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class RestartHard : MonoBehaviour
{
    public Image field, darkness;

    void OnMouseDown()
    {
        StartCoroutine(Restart());
    }

    IEnumerator Restart()
    {
        Destroy(darkness);
        field.DOFade(1.0f, 0.5f);
        yield return new WaitForSeconds(0.5f);
        Application.LoadLevel("Level1");
    }
}
