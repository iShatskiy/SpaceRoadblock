using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorpseFader : MonoBehaviour
{
    public float timeBetweenIterations;
    SpriteRenderer spriteRenderer;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(FadeIn());
        audioSource = GetComponent<AudioSource>();
        if (audioSource.clip != null)
        { 
            audioSource.Play();
        }
    }

    private IEnumerator FadeIn()
    {
        float alphaVal = spriteRenderer.color.a;
        Color tmp = spriteRenderer.color;

        while (spriteRenderer.color.a > 0)
        {
            alphaVal -= 0.01f;
            tmp.a = alphaVal;
            tmp.g = alphaVal;
            tmp.b = alphaVal;
            tmp.r = alphaVal;
            spriteRenderer.color = tmp;

            yield return new WaitForSeconds(timeBetweenIterations);
        }
        Destroy(gameObject);
    }
}
