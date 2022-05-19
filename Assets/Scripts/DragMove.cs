using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragMove : MonoBehaviour
{
    private Touch touch;
    private float speedModifier;

    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void Start()
    {
        Time.timeScale = 1;
        
        speedModifier = 0.01f;
        rb.velocity = transform.forward * 100 * Time.deltaTime;
    }

    void Update()
    {
        
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(
                    transform.position.x + Mathf.Clamp(touch.deltaPosition.x, -20, 20) * -speedModifier,
                    .5f,
                    transform.position.z);
            }
        }
    }
}
