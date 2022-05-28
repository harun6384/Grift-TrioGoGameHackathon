using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;

public class PlayerMechanics : MonoBehaviour
{
    public AudioClip collectSound;
    public GameObject bgMusic;
    public GameObject panel;

    Coroutine co;

    private void Start()
    {
        GameManager.Instance._score.text = GameManager.Instance.score.ToString();
        bgMusic = GameObject.Find("BackgroundAudio");
        panel = GameObject.Find("GameOver");
        panel.SetActive(false);

    }

    private IEnumerator puanEkle()
    {
        WWWForm form = new WWWForm();
        form.AddField("puan", GameManager.Instance.score);

        using (UnityWebRequest www = UnityWebRequest.Post("https://xn--fatihdomu-wkb02e.com/puan-ekle", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                if (www.isDone)
                {
                    StopCoroutine(co);
                }

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BadObj"))
        {
            GameManager.Instance.score -=20;
            GameManager.Instance._score.text = GameManager.Instance.score.ToString();
            other.gameObject.SetActive(false);
            //GameManager.Instance.iyiOrman(other.GetComponentInParent<UCollectible>().after);
            GameManager.Instance.durum -= 10;
            AudioSource.PlayClipAtPoint(collectSound, transform.position); 
        }
        if (other.gameObject.CompareTag("GoodObj"))
        {
            GameManager.Instance.score +=50;
            GameManager.Instance._score.text = GameManager.Instance.score.ToString();
            other.gameObject.SetActive(false);
            GameManager.Instance.durum += 10;
            AudioSource.PlayClipAtPoint(collectSound, transform.position);
        }
        if (other.gameObject.CompareTag("NextTile"))
        {
            GameManager.Instance.nextTile(other.GetComponentInParent<UCollectible>().after);
        }
        if (other.gameObject.CompareTag("EndGame"))
        {
            Time.timeScale = 0;
            bgMusic.SetActive(false);
            panel.SetActive(true);
            co = StartCoroutine(puanEkle());
        }
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    GameManager.Instance.deleteOnBack();
    //}
}
