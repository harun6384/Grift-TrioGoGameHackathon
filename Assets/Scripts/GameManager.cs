using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private System.Random rand = new System.Random(); 
    [SerializeField] public TMP_Text _score, _score2;
    List<int> sayilar = new List<int>();
    public int score = 0;
    public int durum = 50;
    public int bitis = 0;

    public Button btn_home, btn_play_again;

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
        bitis++;
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
        if(bitis == 20 && durum >30)
        {
            _score2.text = "Score: " + score;
            sira = 7;
        }
        if (bitis == 20 && durum <= 30)
        {
            _score2.text = "Score: " + score;
            sira = 8;
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

    public void yenidenBasla()
    {
        bitis = 0;
        sira = 0;
        durum = 0;
        score = 0;
        SceneManager.LoadScene("SampleScene");
    }

    public void anaSayfa()
    {
        SceneManager.LoadScene("UI", LoadSceneMode.Single);
    }

}