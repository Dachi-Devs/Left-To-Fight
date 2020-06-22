using UnityEngine;

public class Attacking : MonoBehaviour
{
    IAttack attackController;
    private bool isAttacking;

    // Start is called before the first frame update
    void Start()
    {
        attackController = GetComponentInChildren<IAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAttacking)
        {
            attackController.StartAttack();
        }
        else
        {
            attackController.EndAttack();
        }
    }

    public void SetAttacking(bool t) => isAttacking = t;
}
