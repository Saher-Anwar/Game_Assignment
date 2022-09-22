using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public new Rigidbody rigidbody;
    public float speed = 4f;
    private Vector3 direction;
    private bool isMoving = false;

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        direction = new Vector3(horizontal, 0f, vertical);

        if (direction.magnitude >= 0.1f)
        {
            //transform.forward = direction;
            float targetAngle = Mathf.Atan2(horizontal, vertical) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, targetAngle, 0);
            isMoving = true;
        }
        else { isMoving = false; }
    }

    private void FixedUpdate()
    {
        if (!isMoving) return;
        rigidbody.MovePosition(rigidbody.position + direction * speed * Time.fixedDeltaTime); 
    }
}
