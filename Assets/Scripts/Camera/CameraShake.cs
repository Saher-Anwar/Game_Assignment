using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    IEnumerator ShakeCamera(float duration, float magnitude)
    {
        Vector3 initialCameraPos = transform.localPosition;

        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;
            transform.localPosition = new Vector3(x, y, initialCameraPos.z);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = initialCameraPos;
    }
}
