using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi2 : MonoBehaviour
{
    public float health = 50f;
    public float timeToGetToPlayer = 3f;
    public float minDistance = 5f;
    public float damage = 25f;

    private float elapsedTime = 0;
    private bool playerFound = false;
    private GameObject player;
    private Vector3 playerPos;
    private Vector3 currPos;

    // Start is called before the first frame update
    void Start()
    {
        currPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerFound)
        {
            elapsedTime += Time.deltaTime;
            transform.position = Vector3.Lerp(currPos, playerPos, elapsedTime / timeToGetToPlayer);

            float dist = Vector3.Distance(playerPos, transform.position);
            if(dist <= minDistance)
            {
                player.GetComponent<Player>().ReduceHealth(damage);
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            playerFound = true;
            playerPos = other.gameObject.transform.position;
            player = other.gameObject;
        }
    }

    public void ReduceHealth(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            KillEnemy();
        }
    }

    public void KillEnemy()
    {
        Destroy(gameObject);
    }
}
