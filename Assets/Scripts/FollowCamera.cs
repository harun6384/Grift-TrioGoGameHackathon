using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 distance;
    public float smooth = 0f;
    private Vector3 velocity = Vector3.zero;
    private Vector3 diffrence;

    private void Start()
    {
        target = GameObject.FindWithTag("Hero").transform;
        diffrence = transform.position - target.position + distance;
    }

    private void LateUpdate()
    {
        Vector3 targetPosition = target.position + diffrence;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smooth);
        //transform.LookAt(target);
    }
}
