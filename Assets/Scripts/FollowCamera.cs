using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 distance;
    public float smooth = 0.3f;
    private Vector3 velocity = Vector3.zero;

    private void Start()
    {
        target = GameObject.FindWithTag("Hero").transform;
        distance = transform.position - target.position;
    }

    private void LateUpdate()
    {
        Vector3 targetPosition = target.position + distance;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smooth);
        transform.LookAt(target);
    }
}
