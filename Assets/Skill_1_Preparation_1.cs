using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_1_Preparation_1 : MonoBehaviour
{
    public ExplosionAbility _explosionAbility;

    public GameObject stage_2_go;
    public GameObject rocketFall;



    public void StartPreparations()
    {
        _explosionAbility.ChangeAmanith();
        GameManager.instance.skill_1_release = true;
        GetComponent<Animator>().SetTrigger("Target");
        StartCoroutine(WaitTarget());
    }

    public void StartTimerAnim()
    {
        stage_2_go.GetComponent<Animator>().SetTrigger("Timer");
        StartCoroutine(WaitTimer());
    }

    public void StartRocket()
    { 
        rocketFall.GetComponent<Animator>().SetTrigger("Shoot");
        StartCoroutine(WaitRocket());
    }

    public void StartRelease()
    { 
        _explosionAbility.Release();
    }

    IEnumerator WaitTarget()
    { 
        yield return new WaitForSeconds(0.8f);
        StartTimerAnim();
    }

    IEnumerator WaitTimer()
    {
        yield return new WaitForSeconds(1.4f);
        StartRocket();
    }

    IEnumerator WaitRocket()
    {
        yield return new WaitForSeconds(.3f);
        StartRelease();
    }
}
    
