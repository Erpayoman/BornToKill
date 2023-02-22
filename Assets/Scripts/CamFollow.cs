using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour {

    
    [SerializeField] Transform target;    
    [SerializeField] float smoothTime = .15f;

    Vector3 velocity = Vector3.zero;
    Vector3 offset;

    private void Start()
    {
        offset = target.position - transform.position;
    }
    void FixedUpdate()
    {
                
        transform.position = Vector3.SmoothDamp(transform.position, target.position - offset, ref velocity, smoothTime);
    }
}
