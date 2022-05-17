using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMechanics : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
          
    }
       
    // Update is called once per frame
    void Update()
    {
         
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BadObj"))
        {
            other.gameObject.SetActive(false);

        }
        if (other.gameObject.CompareTag("GoodObj"))
        {
            other.gameObject.SetActive(false);

        }
    }
}
