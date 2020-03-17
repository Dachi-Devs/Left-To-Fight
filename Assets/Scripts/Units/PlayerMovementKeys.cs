using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementKeys : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Vector3 moveVector = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        GetComponent<IMoveVelocity>().SetVelocity(moveVector);
    }
}
