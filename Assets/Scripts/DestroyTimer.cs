using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTimer : MonoBehaviour
{
    [SerializeField] private float timeToDestroy;
    private float curTime;

    void Start()
    {
        curTime = timeToDestroy;
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
