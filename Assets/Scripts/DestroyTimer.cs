using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTimer : MonoBehaviour
{   
    private AudioSource m_AudioSource;
    [SerializeField] private float timeToDestroy;
    private float curTime;

    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
        curTime = timeToDestroy;
        if (m_AudioSource.clip != null) {
            m_AudioSource.Play();
        }
    }

    void FixedUpdate()
    {
        curTime -= Time.fixedDeltaTime;
        if (curTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
