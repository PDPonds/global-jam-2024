using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 origin = transform.localPosition;
        float elapsed = 0;

        while (elapsed < duration)
        {
            float x = UnityEngine.Random.Range(-1, 1) * magnitude;
            float y = UnityEngine.Random.Range(-1, 1) * magnitude;

            transform.localPosition = new Vector3(x, y, transform.localPosition.z);

            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = origin;
    }
}
