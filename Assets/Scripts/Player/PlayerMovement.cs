using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public GameObject cameraHolder;
    public new Rigidbody rigidbody;
    public float speed = 4f;
    public float gravityScale = -9.81f;
    public float jumpVelocity = 10f;
    public float fallingGravityScale = 15f;
    
    private bool isJumping = false;
    private Vector3 verticalVelocity;

    private bool offPlatform = false;

    private void Start()
    {
        verticalVelocity = new Vector3(0, jumpVelocity, 0);
    }

    // Update is called once per frame
    void Update()
    {
        RotatePlayer();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
        }

    }

    private void FixedUpdate() // called every second
    {
        MovePlayer();

        if (isJumping)
        {
            if (rigidbody.velocity.y > 0)
            {
                verticalVelocity = verticalVelocity + (new Vector3(0f, gravityScale * Time.fixedDeltaTime, 0f));
                rigidbody.velocity = verticalVelocity;
            }

            if (rigidbody.velocity.y <= 0)
            {
                verticalVelocity = verticalVelocity + (new Vector3(0f, fallingGravityScale * Time.fixedDeltaTime, 0f));
                rigidbody.velocity = verticalVelocity;
            }
        }

        if(!isJumping && offPlatform)
        {
            Debug.Log($"Executing, vertical velocity = {rigidbody.velocity}");
            rigidbody.velocity = verticalVelocity + (new Vector3(0f, -2 * Time.fixedDeltaTime, 0f));
            Debug.Log($"New  velocity = {rigidbody.velocity}");
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Ground") || collision.gameObject.tag.Equals("Platform"))
        {
            isJumping = false;
            offPlatform = false;
            verticalVelocity = new Vector3(0, jumpVelocity, 0);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Platform"))
        {
            offPlatform = true;
        }
    }

    private void MovePlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;

        forward.y = 0;
        right.y = 0;
        forward = forward.normalized;
        right = right.normalized;

        Vector3 cameraBasedVerticalMovement = vertical * forward;
        Vector3 cameraBasedRightMovement = horizontal * right;

        Vector3 overallCameraBasedMovement = cameraBasedVerticalMovement + cameraBasedRightMovement;
        transform.Translate(overallCameraBasedMovement * Time.fixedDeltaTime * speed, Space.World);
    }

    private void RotatePlayer()
    {
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, cameraHolder.transform.localEulerAngles.y, transform.localEulerAngles.z);
    }
}
