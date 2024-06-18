using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    // Define the delegate type for the event
    public delegate void CollisionEventHandler(GameObject collider);

    // Define the event using the delegate type
    public static event CollisionEventHandler OnCollisionDetected;

    // Method to trigger the event
    public static void TriggerCollision(GameObject collider)
    {
        if (OnCollisionDetected != null)
        {
            OnCollisionDetected.Invoke(collider);
        }
    }
}
