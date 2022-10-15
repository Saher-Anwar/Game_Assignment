using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    public float upwardLimit = 5;
    public float downwardLimit = -5;
    public float moveSpeed = 4f;

    private int directionToMove = 1;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > upwardLimit)
        {
            directionToMove = -1;
        }
        else if (transform.position.y < downwardLimit)
        {
            directionToMove = 1;
        }

        MovePlatform();
    }

    private void MovePlatform()
    {
        Vector3 horizontalMovement = Vector3.up * directionToMove * moveSpeed * Time.deltaTime;
        transform.Translate(horizontalMovement);
    }
}
