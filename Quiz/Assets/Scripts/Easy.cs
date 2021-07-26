using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Easy : MonoBehaviour
{
    public Text task;
    public Image field;
    public GameObject square;
    public GameObject[] letters;
    public GameObject[] numbers;
    GameObject[] objects;
    public GameObject[] final = new GameObject[3];
    public string obj;

    void Start()
    {
        field.DOFade(0f, 0.5f);

        System.Random rnd = new System.Random();
        int a, len = 0;
        a = rnd.Next(2);
        if (a == 0)
        {
            objects = letters;
            len = 26;
        }
        if (a == 1)
        {
            objects = numbers;
            len = 10;
        }

        int[] id = new int[3];
        id[0] = rnd.Next(0, len);
        for (int i = 1; i < 3;)
        {
            int num = rnd.Next(0, len);
            int j;
            for (j = 0; j < i; j++)
            {
                if (num == id[j])
                    break;
            }
            if (j == i)
            {
                id[i] = num;
                i++;
            }
        }

        a = rnd.Next(3);

        Instantiate(square, new Vector3(-5f, -1.5f, 5f), Quaternion.identity);
        final[0] = Instantiate(objects[id[0]], new Vector3(-5f, -1.5f, 2.5f), Quaternion.identity) as GameObject;
        final[0].transform.DOShakePosition(1f, strength: new Vector3(0, 2, 0), vibrato: 5, randomness: 1, snapping: false, fadeOut: true);
        final[0].name = objects[id[0]].name;
        if (a == 0)
            obj = final[0].name;

        Instantiate(square, new Vector3(0f, -1.5f, 5f), Quaternion.identity);
        final[1] = Instantiate(objects[id[1]], new Vector3(0f, -1.5f, 2.5f), Quaternion.identity) as GameObject;
        final[1].transform.DOShakePosition(1f, strength: new Vector3(0, 2, 0), vibrato: 5, randomness: 1, snapping: false, fadeOut: true);
        final[1].name = objects[id[1]].name;
        if (a == 1)
            obj = final[1].name;

        Instantiate(square, new Vector3(5f, -1.5f, 5f), Quaternion.identity);
        final[2] = Instantiate(objects[id[2]], new Vector3(5f, -1.5f, 2.5f), Quaternion.identity) as GameObject;
        final[2].transform.DOShakePosition(1f, strength: new Vector3(0, 2, 0), vibrato: 5, randomness: 1, snapping: false, fadeOut: true);
        final[2].name = objects[id[2]].name;
        if (a == 2)
            obj = final[2].name;

        task.text = "Find " + obj;
        task.DOFade(1.0f, 5.0f);
    }
}