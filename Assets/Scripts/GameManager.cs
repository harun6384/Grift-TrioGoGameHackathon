using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private System.Random rand = new System.Random(); 
    [SerializeField] public TMP_Text _score;
    List<int> sayilar = new List<int>();
    public int score = 0;
    public int durum = 50;

    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("GameManager");
                go.AddComponent<GameManager>();
            }
            return _instance;
        }
    }

    int sira = 0;

    private void Awake()
    {
        _instance = this;
    }


    public GameObject[] biyom1 = new GameObject[7];
    private Queue biyomObjects = new Queue();

    [SerializeField] GameObject player;

    void Start()
    {
        Instantiate(player, transform.GetChild(0).transform);
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    public void siraOlustur()
    {
        if (durum <= 30)
        {
            sira = rand.Next(4, 7);
        }
        if (durum > 30 && durum <= 70)
        {
            sira = rand.Next(1,4);
        }
        if (durum > 70)
        {
            sira = 0;
        }
    }
    

    public void nextTile(Transform after)
    {
        siraOlustur();
        biyomObjects.Enqueue(Instantiate(biyom1[sira], after));
    }

    //public void deleteOnBack()
    //{
    //    Destroy((GameObject)biyomObjects.Dequeue());
    //}

    private void CreateMap()
    {
        Instantiate(biyom1[sira], transform.parent);
    }

}