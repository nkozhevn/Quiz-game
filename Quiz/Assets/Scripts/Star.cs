using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Star : MonoBehaviour
{
    SpriteRenderer star;

    void Start()
    {
        star = GetComponent<SpriteRenderer>();
        Destroy(gameObject, 1f);
    }

    void Update()
    {
        star.color = new Color(star.color.r, star.color.g, star.color.b, Mathf.PingPong(Time.time / 0.5f, 1.0f));
    }
}
