using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField]private int hp;
    [SerializeField]private int speed;
    private bool dead;
    private bool stun;
    private Animator anim;
    [SerializeField]private float stunTime;
    private float curStunTime;
    [SerializeField] private int countAmanith;
    private AudioSource audioSource;
    [SerializeField] private GameObject corpse;
    [SerializeField] private AudioClip soundHit;

    public void Awake() {
        anim = GetComponentInChildren<Animator>();
        audioSource = GetComponentInChildren<AudioSource>();
        curStunTime = stunTime;
    }

    public void FixedUpdate() {
        if (curStunTime > 0) {
            curStunTime -= Time.fixedDeltaTime;
            return;
        }
        if (dead != true)
            anim.SetBool("Walk", true);
            gameObject.transform.Translate(Vector2.left * (speed * 0.01f));
    }

    public void ApplyDamage(int damage) {
        hp -= damage;
        curStunTime += stunTime;
        anim.SetTrigger("Hit");
        audioSource.PlayOneShot(soundHit);
        if (hp <= 0)
            Death();
    }

    private void Death() {
        dead = true;
        GameManager.instance.CountEnemies--;
        GameManager.instance.ChangeAmanith(countAmanith);
        ReleaseCorpse();
        Destroy(gameObject);
    }

    public void Attack() {
        GameManager.instance.ChangeHp(-1);
        dead = true;
        GameManager.instance.CountEnemies--;
        Destroy(gameObject);
    }

    public void ReleaseCorpse() {
        if (corpse != null)
        {
            Instantiate(corpse, transform.position, Quaternion.identity);
        }
        else 
        {
            Debug.Log("This enemy has no corpse prefab.");
        }
    }
}
