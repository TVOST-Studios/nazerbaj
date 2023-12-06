using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmissionLooper : MonoBehaviour
{
    public float minIntensity = 0f;
    public float maxIntensity = 2f;
    public float duration = 1f;

    private Material mat;
    private Color baseEmissionColor;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
        baseEmissionColor = mat.GetColor("_EmissionColor");
        StartCoroutine(LoopEmissionIntensity());
    }

    IEnumerator LoopEmissionIntensity()
    {
        while (true)
        {
            for (float t = 0; t < duration; t += Time.deltaTime)
            {
                float intensity = Mathf.Lerp(minIntensity, maxIntensity, t / duration);
                mat.SetColor("_EmissionColor", baseEmissionColor * intensity);
                yield return null;
            }

            for (float t = 0; t < duration; t += Time.deltaTime)
            {
                float intensity = Mathf.Lerp(maxIntensity, minIntensity, t / duration);
                mat.SetColor("_EmissionColor", baseEmissionColor * intensity);
                yield return null;
            }
        }
    }
}