using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformHorizontalMovementController : MonoBehaviour
{
    public float horizontalRightLimit = 5;
    public float horizontalLeftLimit = -5;
    public float moveSpeed = 4f;

    private int directionToMove = 1;

    // Update is called once per frame
    void Update()
    {
        if (transform.localPosition.x > horizontalRightLimit)
        {
            directionToMove = -1;
        }
        else if (transform.localPosition.x < horizontalLeftLimit)
        {
            directionToMove = 1;
            Debug.Log("going overboard");
        }

        MovePlatform();
    }

    private void MovePlatform()
    {
        Vector3 horizontalMovement = Vector3.right * directionToMove * moveSpeed * Time.deltaTime;
        transform.Translate(horizontalMovement);
    }
}
