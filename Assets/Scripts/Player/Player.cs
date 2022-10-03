using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    enum PLAYER_STATE
    {
        IDLE,
        MOVING,
        JUMPING_UP,
        FALLING_DOWN,
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Lava"))
        {
            PlayerDeath();
        }
    }

    public void PlayerDeath()
    {
        Destroy(gameObject);
    }
}
