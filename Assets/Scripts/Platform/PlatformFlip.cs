using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFlip : MonoBehaviour
{
    public float flipTime = 3f;

    private Vector3 targetRotation;
    private float elapsedTime = 0;
    private bool isFlipped = false;

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (!isFlipped)
        {
            if(elapsedTime >= flipTime)
            {
                transform.Rotate(new Vector3(0, 0, 90));
                isFlipped = true;
                elapsedTime = 0;
            }
        }
        else
        {
            if(elapsedTime >= flipTime)
            {
                transform.Rotate(new Vector3(0, 0, -90));
                isFlipped = false;
                elapsedTime = 0;
            }
        }
    }
}
