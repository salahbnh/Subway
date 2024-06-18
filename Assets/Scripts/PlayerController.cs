using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    Rigidbody rb;

    public float moveSpeed = 5.0f;
    public float laneWidth = 4.0f;
    private int currentLane = 1; // Start in the middle lane (0 for left, 1 for center, 2 for right).
    public float force;
    Vector3 moveUp = new Vector3(0f, 25.0f, 0f);
    public bool canJump = true;


    public static int highScore;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetButtonDown("left"))
        {
            currentLane--;
            if (currentLane == -1)
            {
                currentLane = 0;
            }
        }
        else if (Input.GetButtonDown("right"))
        {
            currentLane++;
            if (currentLane == 3)
            {
                currentLane = 2;
            }
        }
       
       
        if (Input.GetButtonDown("Jump") && canJump)
        {
            rb.AddForce(moveUp * force);
            canJump = false;
        }

        Vector3 targetPosition = new Vector3(transform.position.x, transform.position.y, (currentLane - 1) * laneWidth);

        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * moveSpeed);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Equals("Plane"))
        {
            canJump = true;
        }
    }
}
