using UnityEngine;

public class MeleeAttack : MonoBehaviour, IAttack
{
    [SerializeField]
    private GameObject meleeHitbox;
    [SerializeField]
    private Transform meleePosition;
    [SerializeField]
    private float swingRate;
    private float cooldown = 0;
    private bool attacking;
    [SerializeField]
    private MeleeSO meleeSO;

    public void StartAttack() => attacking = true;
    public void EndAttack() => attacking = false;

    void Update()
    {
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }

        if (attacking)
        {
            if (cooldown <= 0)
            {
                SwingMelee();
                cooldown = swingRate;
            }
        }
    }

    public void SwingMelee()
    {
        Debug.Log("MELEE ATTACK");
        Melee melee = Instantiate(meleeHitbox, meleePosition.position, Quaternion.identity).GetComponent<Melee>();
        melee.Setup(meleeSO);
    }
}
