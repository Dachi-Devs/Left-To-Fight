using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private KeyCode interactKey;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(interactKey))
        {
            GetComponentInChildren<PlayerInteraction>().CallInteraction();
        }

        if (Input.GetKey(KeyCode.Mouse0))
            GetComponent<Attacking>().SetAttacking(true);
        else
            GetComponent<Attacking>().SetAttacking(false);
    }
}
