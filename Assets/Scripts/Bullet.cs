using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 1;
    private float damage;

    public void Setup(float speed, float damage, Sprite sprite)
    {
        this.speed = speed;
        this.damage = damage;
        GetComponentInChildren<SpriteRenderer>().sprite = sprite;
    }

    void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        Health health = GetComponent<Health>();
        if (health != null)
        {
            health.Damage(damage);
        }

        Destroy(gameObject);
    }
}
