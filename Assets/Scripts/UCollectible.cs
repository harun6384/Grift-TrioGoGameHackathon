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
        //current = rand.Next(0, 2) == 1;
        int temp;

        for (int i = 0; i <= 2;i++)
        {
            //int a = rand.Next(1, 4);

            temp = rand.Next(1, 3);
            switch (i + 1)
            {
                case 1:
                    Instantiate(temp == 1 ? iyi : kotu, sp[rand.Next(1, 3) == 1 ? 0 : 1]);
                    break;
                case 2:
                    Instantiate(current ? kotu : iyi, sp[rand.Next(1, 3) == 1 ? 2 : 3]);
                    break;
                /*case 3:
                    Instantiate(current ? iyi : kotu, sp[3]);
                    break;
                case 4:
                    Instantiate(current ? iyi : kotu, sp[4]);
                    break;*/
                default:
                    break;
            }
            
            if (temp == 1) current = true;

            //if (!sayilar.Contains(a))
            //{
            //    sayilar.Add(a);
            //    i++;

            //    switch (a)
            //    {
            //        case 1:
            //            Instantiate(current ? iyi : kotu, sp[1].transform);
            //            break;
            //        case 2:
            //            Instantiate(current ? iyi : kotu, sp[2].transform);
            //            break;
            //        //case 3:
            //        //    Instantiate(current ? iyi : kotu, sp[3].transform);
            //        //    break;
            //        //case 4:
            //        //    Instantiate(current ? iyi : kotu, sp[4].transform);
            //        //    break;
            //        default:
            //            break;
            //    }
            //    current = !current;
            //}
        }
    }
}
