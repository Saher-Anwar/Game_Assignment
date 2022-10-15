using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class VolcanoEruption : MonoBehaviour
{
    public float waitTime = 3f;
    public float particleEffectTime = 5f;
    public Vector3 overlapBoxOffset = new Vector3(0,0,0);
    public Vector3 overlapBoxSize = new Vector3(0, 0, 0);

    private new ParticleSystem particleSystem;
    private bool started = false;
    // Start is called before the first frame update
    void Start()
    {
        particleSystem = GetComponentInChildren<ParticleSystem>();
        started = true;
        StartCoroutine("PlayParticleEffects");
    }

    IEnumerator PlayParticleEffects()
    {
        while (true)
        {
            particleSystem.Play();
            Collider[] hitColliders = Physics.OverlapBox((gameObject.transform.position + overlapBoxOffset), overlapBoxSize, Quaternion.identity);
            int i = 0;
            while(i < hitColliders.Length)
            {
                if (hitColliders[i].tag.Equals("Player"))
                {
                    hitColliders[i].GetComponent<Player>().ReduceHealth(30);
                }
                i++;
            }
            yield return new WaitForSeconds(5f);
            
            yield return new WaitForSeconds(waitTime);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Check that it is being run in Play Mode, so it doesn't try to draw this in Editor mode
        if (started)
            //Draw a cube where the OverlapBox is (positioned where your GameObject is as well as a size)
            Gizmos.DrawWireCube(transform.position + overlapBoxOffset, overlapBoxSize);
    }

}
