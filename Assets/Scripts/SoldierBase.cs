using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class SoldierBase : MonoBehaviour
{
    [SerializeField] private Gun gun;
    [SerializeField] private float cooldownTime;
    [SerializeField] private float aggroDistance;

    private float currentCooldownTime;
    private bool cooldown;
    private Animator animator;
    public int position;
    public int price;

    public int curLevelAttack;
    public int curLevelSpeed;

    public bool prepared {
        set { 
            animator.SetBool("Prepare", value);
        }
    }

    public void Awake()
    {
        
        currentCooldownTime = cooldownTime;
        animator = GetComponentInChildren<Animator>();
        prepared = false;
    }

    private void Attack() {
        if (animator != null) {
            animator.SetTrigger("Attack");
        }
        gun.Shoot();
        cooldown = true;
    }

    public void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, aggroDistance);
        if (hit.collider != null)
            if (hit.collider.tag == "Enemy") {
                if (cooldown == false)
                {
                    Attack();
                }
                else
                {
                    CooldownTimer();
                }
            }
    }

    private void CooldownTimer() {
        if (currentCooldownTime > 0)
        {
            currentCooldownTime -= Time.deltaTime;
        }
        else 
        {
            currentCooldownTime = cooldownTime;
            cooldown = false; 
        }
    }

    public void UpgradeSpeed(float value) {
        curLevelSpeed++;
        cooldownTime = value;
    }

    public void UpgradeAttack(int value)
    {
        curLevelAttack++;
        gun.damage = value;
    }
}
