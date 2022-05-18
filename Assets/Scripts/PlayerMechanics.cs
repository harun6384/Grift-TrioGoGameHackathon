using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerMechanics : MonoBehaviour
{
    

    [SerializeField] private TMP_Text _score;

    private void Start()
    {
        _score.text = GameManager.Instance.score.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BadObj"))
        {
            GameManager.Instance.score -=20;
            _score.text = GameManager.Instance.score.ToString();
            other.gameObject.SetActive(false);
            GameManager.Instance.kotuOrman();
        }
        if (other.gameObject.CompareTag("GoodObj"))
        {
            GameManager.Instance.score +=50;
            _score.text = GameManager.Instance.score.ToString();
            other.gameObject.SetActive(false);
            GameManager.Instance.iyiOrman();
        }
    }
}
