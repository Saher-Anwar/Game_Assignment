using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public new Rigidbody rigidbody;
    public float speed = 4f;
    public float gravityScale = -9.81f;
    public float jumpVelocity = 10f;
    public float fallingGravityScale = 15f;
    public float turnSmoothTime = 0.1f;
    
    private Vector3 direction;
    private bool isJumping = false;
    private Vector3 verticalVelocity;
    private float turnSmoothVelocity;

    private void Start()
    {
        verticalVelocity = new Vector3(0, jumpVelocity, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(horizontal, vertical) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0, angle, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
        }

    }

    private void FixedUpdate() // called every second
    {
        rigidbody.MovePosition(rigidbody.position + direction * speed * Time.fixedDeltaTime);

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

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Ground") || collision.gameObject.tag.Equals("Platform"))
        {
            isJumping = false;
            verticalVelocity = new Vector3(0, jumpVelocity, 0);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        //if(collision.gameObject.tag.Equals("Ground") || collision.gameObject.tag.Equals("Platform"))
        //{
        //    isJumping = true;
        //    verticalVelocity = verticalVelocity + (new Vector3(0f, fallingGravityScale * Time.fixedDeltaTime, 0f));
        //    rigidbody.velocity = verticalVelocity;
        //}
    }
}
