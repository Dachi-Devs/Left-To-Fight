﻿using UnityEngine;

public class Bullet : MonoBehaviour
{
    private BulletSO bulletSO;
    private float lifespan = 1.5f;
    private float speed = 125f;


    public void Setup(BulletSO bullSO)
    {
        bulletSO = bullSO;
        GetComponentInChildren<SpriteRenderer>().sprite = bulletSO.bulletSprite;
        gameObject.name = bullSO.name;
    }

    void Update()
    {
        transform.position += transform.up * speed * bulletSO.speedMod * Time.deltaTime;
        lifespan -= Time.deltaTime;

        if (lifespan < 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        Health health = coll.transform.GetComponent<Health>();
        if (health != null)
        {

            health.Damage(bulletSO.damage, bulletSO.armourPen);
        }

        if (!bulletSO.penetration)
        {
            Destroy(gameObject);
        }
    }
}
