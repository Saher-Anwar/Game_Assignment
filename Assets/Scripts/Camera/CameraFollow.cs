using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    [Range(0f,1f)]
    public float smoothSpeed;

    public float horizontalSpeed = 2f;
    public float verticalSpeed = 2f;

    private float yaw = 0f;
    private float pitch = 0f;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(player == null) return;
        Rotate();
        Vector3 desiredPos = player.position + offset;
        Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed);
        transform.position = smoothedPos;

        transform.LookAt(player);
    }

    void Rotate()
    {
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X"), Vector3.up) * offset;
    }
}
