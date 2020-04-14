using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{


    private float cooldown = 1f;

    // Update is called once per frame
    void Update()
    {
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }

        if (Input.GetAxisRaw("FirePrimary") == 1)
        {
            if (cooldown < 0)
            {
                cooldown = 1f;
                FireBullet();
            }
        }
    }

    void FireBullet()
    {
        GetComponentInChildren<GunController>().FireBullet();
    }
}
