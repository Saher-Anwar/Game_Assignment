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

    public float health = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReduceHealth(float reduction)
    {
        health -= reduction;
        if(health <= 0)
        {
            PlayerDeath();
        }
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
