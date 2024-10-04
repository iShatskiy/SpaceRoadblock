using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBase : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy") {
            collision.gameObject.GetComponent<EnemyBase>().Attack();
        }
    }
}
