using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : Bullet
{
    Animator anim;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(TimeToExplode(1));
    }

    void Explosion()
    {
        anim.SetTrigger("Explode");
        RaycastHit2D[] hit = Physics2D.CircleCastAll(transform.position, 3f, Vector2.zero);
        if (hit[0].collider != null)
            if (hit[0].collider.tag == "Enemy")
            {
                foreach (var enemy in hit)
                {
                    enemy.collider.gameObject.GetComponent<EnemyBase>().ApplyDamage(damage);
                }
            }
        StartCoroutine(TimeToDestroy(2));
    }

    IEnumerator TimeToExplode(float time)
    {
        yield return new WaitForSeconds(time);
        Explosion();
    }

    IEnumerator TimeToDestroy(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
