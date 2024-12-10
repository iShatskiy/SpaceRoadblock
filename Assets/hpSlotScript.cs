using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hpSlotScript : MonoBehaviour
{
    Animator anim;
    bool empty; 

    public void Awake()
    {
        anim = GetComponent<Animator>();    
    }

    public void TakeDamage()
    {
        if (!empty)
        {
            anim.SetTrigger("dmg");
            empty = true;
        }
    }
}
