using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    System.Random rand = new System.Random();
    List<int> sayilar = new List<int>();
    public int score = 0;

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

        if (Input.GetKeyDown(KeyCode.A))
        {
            biyomObjects.Enqueue(Instantiate(biyom1[1], transform));
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (biyomObjects.Count > 0)
                Destroy((GameObject)biyomObjects.Dequeue());
        }
    }


    public void iyiOrman()
    {
        int temp = sira - 1;
        if (biyom1[temp] != null)
            biyomObjects.Enqueue(Instantiate(biyom1[++sira]));
        CreateMap();
    }

    public void kotuOrman()
    {
        int temp = sira - 1;
        if (biyom1[temp] != null)
            biyomObjects.Enqueue(Instantiate(biyom1[++sira]));
        CreateMap();
    }

    private void CreateMap()
    {
        Instantiate(biyom1[sira], transform.parent);
    }

}