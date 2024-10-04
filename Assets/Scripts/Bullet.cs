using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 1;
    [SerializeField] float lifetime = 3f;
    public float missRate = 1f;
    public int damage;
    private Vector2 direction;

    [SerializeField] private GameObject particle;

    public void Start()
    {
        direction = new Vector2(1 * speed * .1f, Random.Range(-0.002f * missRate, 0.01f * missRate));
    }

    public void FixedUpdate()
    {
        transform.Translate(direction);
        lifetime -= Time.deltaTime;
        if (lifetime < 0) {
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Enemy") {
            collision.gameObject.GetComponent<EnemyBase>().ApplyDamage(damage);
            Instantiate(particle, transform.position+Vector3.right, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
