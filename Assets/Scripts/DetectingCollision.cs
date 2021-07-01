using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectingCollision : MonoBehaviour
{
    public bool collisionDetected;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            collisionDetected = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            collisionDetected = false;
        }
    }
}
