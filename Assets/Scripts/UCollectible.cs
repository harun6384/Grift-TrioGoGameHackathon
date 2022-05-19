using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UCollectible : MonoBehaviour
{

    System.Random rand = new System.Random();
    public Transform after;

    public Transform[] sp;
    List<int> sayilar = new List<int>();
    [SerializeField] GameObject iyi, kotu, nextTile;

    private void OnEnable()
    {
        bool current = false;
        current = rand.Next(0, 2) == 1;

        for (int i = 0; i < 2;)
        {
            int a = rand.Next(1, 4);


            if (!sayilar.Contains(a))
            {
                sayilar.Add(a);
                i++;

                switch (a)
                {
                    case 1:
                        Instantiate(current ? iyi : kotu, sp[1].transform);
                        break;
                    case 2:
                        Instantiate(current ? iyi : kotu, sp[2].transform);
                        break;
                    case 3:
                        Instantiate(current ? iyi : kotu, sp[3].transform);
                        break;
                    case 4:
                        Instantiate(current ? iyi : kotu, sp[4].transform);
                        break;
                    default:
                        break;
                }
                current = !current;
            }
        }
    }
}
