using UnityEngine;

public class Attacking : MonoBehaviour
{
    IAttack attackController;

    // Start is called before the first frame update
    void Start()
    {
        attackController = GetComponentInChildren<GunController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("FirePrimary") == 1)
        {
            attackController.StartAttack();
        }
        else
        {
            attackController.EndAttack();
        }
    }
}
