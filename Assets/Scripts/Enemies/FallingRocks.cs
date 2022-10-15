using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingRocks : MonoBehaviour
{
    public Camera mainCamera;
    public Vector3 rockPosition = new Vector3(0, 0, 0);
    public float shakeDuration = 3f;
    public float shakeMagniture = .5f;
    public GameObject rockPrefab;

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
        if (collision.gameObject.tag.Equals("Player"))
        {
            StartCoroutine(mainCamera.GetComponent<CameraShake>().ShakeCamera(3f, 1f));
            Instantiate(rockPrefab, transform.position + rockPosition, Quaternion.identity);
        }
    }
}
