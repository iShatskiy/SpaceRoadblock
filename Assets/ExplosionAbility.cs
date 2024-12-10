using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ExplosionAbility : MonoBehaviour
{
    Animator anim;
    AudioSource audioS;
    public int price;
    public int damage;
    [SerializeField] private Button b;

    void Start()
    {
        audioS = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (b == null)
            { return; }
        if (GameManager.instance.countAmanith < price || GameManager.instance.skill_1_release)
        {
            b.enabled = false;
        }
        else { 
            b.enabled = true;
        }
    }

    public void ChangeAmanith()
    {
        GameManager.instance.ChangeAmanith(-price);
    }

    public void Explosion()
    {
        anim.SetTrigger("Explosion");
        audioS.Play();
        RaycastHit2D[] hit = Physics2D.CircleCastAll(transform.position, 8f, Vector2.zero);
        if (hit.Length > 0)
        {
            foreach (var enemy in hit)
            {
                if (enemy.collider.tag == "Enemy")
                    enemy.collider.gameObject.GetComponent<EnemyBase>().ApplyDamage(damage);
            }

        }

        
    }
    public void Release()
    {
        //Camera.main.GetComponent<CameraShaker>().shakeDuration = 0.5f;
        Camera.main.GetComponent<Animator>().SetTrigger("Shake");
        Explosion();
        GameManager.instance.skill_1_release = false;
    }
}
