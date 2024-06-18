using System;
using System.Collections.Generic;
using UnityEngine;

public class RoadController : MonoBehaviour
{ 
    public float moveSpeed = 10.0f;
    void Update()
    {
        transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("endCollider"))
        {
        // Trigger the collision event and pass the colliding object
            EventManager.TriggerCollision(other.gameObject);
        }
    }
}
