using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public float horizontalRightLimit = 0;
    public float horizontalLeftLimit = 0;
    public float verticalRightLimit = 0;
    public float verticalLeftLimit = 0;
    public bool moveHorizontal;
    public bool moveVertical;
    public float movementTime = 4f;

    private Vector3 currentPosition;
    private float timeElapsed = 0;
    private bool isMovingRight = false;
    private bool isFirstIterationDone = false;

    // Start is called before the first frame update
    void Start()
    {
        currentPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (moveHorizontal)
        {
            // if platform gone past right side switch direction; else switch other way
            if (transform.localPosition.x >= horizontalRightLimit)
            {
                isMovingRight = false;
                timeElapsed = 0.01f;
                currentPosition = transform.localPosition;
            }
            else if (transform.localPosition.x <= horizontalLeftLimit)
            {
                isMovingRight = true;
                isFirstIterationDone = true;

                timeElapsed = 0.01f;
                currentPosition = transform.localPosition;
            }

            // since platform starts in the middle, it only travels half way before switching so the distance multiplies but the time to move remains same. So just multiple 
            // movement time by 2 to make up for it
            if (isFirstIterationDone) {
                isFirstIterationDone = false;
                movementTime *= 2;
            }

            // when direction switched is true, move towards the right; otherwise, move towards left
            if (isMovingRight)
            {
                transform.localPosition = Vector3.Lerp(currentPosition, new Vector3(horizontalRightLimit,0,0), timeElapsed / movementTime);
            }
            else
            {
                transform.localPosition = Vector3.Lerp(currentPosition, new Vector3(horizontalLeftLimit, 0, 0), timeElapsed / movementTime);
            }

            
        }

        if (moveVertical)
        {

        }
    }

    void movePlatformHorizontally()
    {

    }

    void movePlatformVerticall()
    {

    }
}
