using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] private float forwardSpeed;
    [SerializeField] private float yawSpeed;

    void Start()
    {
        
    }

    
    void Update()
    {
        float horizontalAxis = Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;
        this.transform.Translate(horizontalAxis, 0, forwardSpeed * Time.deltaTime);
    }
}
