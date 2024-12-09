using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public int damage;
    protected AudioSource audioShot;

    private void Start()
    {
        audioShot = GetComponent<AudioSource>();
    }

    public virtual void Shoot() {
        
    }
}
