using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float xMin = -4f, xMax = 1f;
    [SerializeField] private float forwardSpeed;
    [SerializeField] private float yawSpeed;

    void Start()
    {
        
    }

    
    void Update()
    {
        float xPos = Mathf.Clamp(this.transform.position.x - Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime, xMin, xMax);
        //float horizontalAxis = Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;
        //this.transform.Translate(-(xPos), 0, -(forwardSpeed * Time.deltaTime));
        this.transform.position = new Vector3(xPos, 0.5f, this.transform.position.z-(forwardSpeed * Time.deltaTime));
    }
}
