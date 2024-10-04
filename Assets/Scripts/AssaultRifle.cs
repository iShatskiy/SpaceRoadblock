using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultRifle : Gun
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float missRate;
    public override void Shoot() {
        Instantiate(bullet, transform.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().damage = damage;
        bullet.GetComponent<Bullet>().missRate = missRate;
    }
}
