using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : Gun
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float missRate;
    public override void Shoot()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right);
        if (hit.collider != null)
            if (hit.collider.tag == "Enemy")
            {
                Instantiate(bullet, hit.collider.transform.position - new Vector3(2, 0, 0), Quaternion.identity);
            }
        bullet.GetComponent<Bullet>().damage = damage;
        bullet.GetComponent<Bullet>().missRate = missRate;
    }
}
