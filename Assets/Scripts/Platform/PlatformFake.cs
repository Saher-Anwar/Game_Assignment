using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFake : MonoBehaviour
{
    public Material enabledMaterial;
    public Material disabledMaterial;
    public float time = 3f;
    public bool isColliderEnabled = true;

    private float elapsedTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (isColliderEnabled)
        {
            gameObject.GetComponent<MeshRenderer>().material = enabledMaterial;
            gameObject.GetComponent<BoxCollider>().enabled = true;
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().material = disabledMaterial;
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (isColliderEnabled)
        {
            if(elapsedTime >= time)
            {
                gameObject.GetComponent<BoxCollider>().enabled = false;
                gameObject.GetComponent<MeshRenderer>().material = disabledMaterial;
                isColliderEnabled = false;
                elapsedTime = 0;
            }
        }
        else
        {
            if(elapsedTime >= time)
            {
                gameObject.GetComponent<BoxCollider>().enabled = true;
                gameObject.GetComponent<MeshRenderer>().material = enabledMaterial;
                isColliderEnabled = true;
                elapsedTime = 0;
            }
        }
    }
}
