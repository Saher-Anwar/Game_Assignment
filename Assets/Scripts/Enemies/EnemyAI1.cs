using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI1 : MonoBehaviour
{
    public float travelTime = 3f;
    public float waitToDestroy = 1f;

    private Player player;
    private Vector3 playerPos;
    private Vector3 currPos;

    private float elapsedTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        playerPos = player.transform.position;
        currPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        Debug.Log(transform.position);
        transform.position = Vector3.Lerp(currPos, playerPos, elapsedTime / travelTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            other.gameObject.GetComponent<Player>().ReduceHealth(50);
        }

        GetComponentInChildren<ParticleSystem>().Play();
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        StartCoroutine(DestroyGameObject());
    }

    IEnumerator DestroyGameObject()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
