using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_1_Preparation_1 : MonoBehaviour
{
    public GameObject stage_2;
    public GameObject rocketFall;
    public void StartPreparations()
    {
        GetComponent<Animator>().SetTrigger("Target");
        StartCoroutine(Wait());
    }

    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        stage_2.GetComponent<Animator>().SetTrigger("Timer");
        StartCoroutine(Rocket());
    }

    public IEnumerator Rocket()
    {
        yield return new WaitForSeconds(2);
        rocketFall.GetComponent<Animator>().SetTrigger("Shoot");
    }
}
    
