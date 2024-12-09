using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]protected float speed = 1;
    [SerializeField]protected float lifetime = 3f;
    public float missRate = 1f;
    public int damage;
    protected AudioSource mAudioHit;

    public void Start()
    {
        mAudioHit = GetComponent<AudioSource>();
    }
}
