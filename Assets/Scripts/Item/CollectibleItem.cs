using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    public float upwardLimit = 5;
    public float downwardLimit = -5;
    public float moveSpeed = 4f;
    public float degrees = 20f;

    private int directionToMove = 1;

    // Update is called once per frame
    void Update()
    {
        if (transform.localPosition.y > upwardLimit)
        {
            directionToMove = -1;
        }
        else if (transform.localPosition.y < downwardLimit)
        {
            directionToMove = 1;
        }

        LevitateItem();
        transform.Rotate(0, degrees * Time.deltaTime, 0);
    }

    private void LevitateItem()
    {
        Vector3 horizontalMovement = Vector3.up * directionToMove * moveSpeed * Time.deltaTime;
        transform.Translate(horizontalMovement);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
            GameManager.instance.LoadNextScene();
        }
    }
}
