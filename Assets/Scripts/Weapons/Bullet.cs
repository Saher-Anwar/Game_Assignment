using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float force = 5f;
    public float delayBeforeDestroy = 5f;
    public GameObject cameraHolder;
    public float damage = 10f;

    Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        cameraHolder = FindObjectOfType<CameraFollow>().gameObject;
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, cameraHolder.transform.localEulerAngles.y, transform.localEulerAngles.z);
        velocity = transform.forward * force;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().AddForce(velocity, ForceMode.Acceleration);
        Destroy(gameObject, delayBeforeDestroy);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Enemey"))
        {
            // deal damage to enemy
            other.GetComponent<EnemyAi2>().ReduceHealth(damage);
        } else if (!other.gameObject.tag.Equals("Player"))
        {
            Destroy(gameObject);
        }
    }
}
