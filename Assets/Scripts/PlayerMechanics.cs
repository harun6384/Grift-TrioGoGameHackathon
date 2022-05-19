using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerMechanics : MonoBehaviour
{
    public AudioClip collectSound;

    private void Start()
    {
        GameManager.Instance._score.text = GameManager.Instance.score.ToString();
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

        }
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    GameManager.Instance.deleteOnBack();
    //}
}
