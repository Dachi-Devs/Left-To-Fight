using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : Attacking
{
    GunController gc;

    void Start()
    {
        gc = GetComponentInChildren<GunController>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("FirePrimary") == 1)
        {
            gc.TriggerPulled();
        }
        else
        {
            gc.TriggerReleased();
        }
    }
}
