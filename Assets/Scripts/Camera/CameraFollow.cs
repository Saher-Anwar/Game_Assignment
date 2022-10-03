using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    [Range(0f,1f)]
    public float smoothSpeed;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 desiredPos = player.position + offset;
        Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed);
        transform.position = smoothedPos;

        transform.LookAt(player);
    }
}
