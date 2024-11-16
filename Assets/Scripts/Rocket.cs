using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : Bullet
{
    private Vector2 direction;
    [SerializeField] private GameObject particle;

    void Start()
    {
        direction = new Vector2(1 * speed * .1f, Random.Range(-0.01f * missRate, 0.01f * missRate));
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Enemy")
        {
            Explosion();
            Instantiate(particle, transform.position + Vector3.right, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    void Explosion()
    {
        RaycastHit2D[] hit = Physics2D.CircleCastAll(transform.position, 2.4f, Vector2.zero);
        if (hit.Length > 0)
        {
            foreach (var enemy in hit)
            {
                if (enemy.collider.tag == "Enemy")
                    enemy.collider.gameObject.GetComponent<EnemyBase>().ApplyDamage(damage);
            }

        }
    }
    public void FixedUpdate()
    {
        transform.Translate(direction);
        lifetime -= Time.deltaTime;
        if (lifetime < 0)
        {
            Destroy(gameObject);
        }
    }
}
