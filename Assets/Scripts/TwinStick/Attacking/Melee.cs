using UnityEngine;

public class Melee : MonoBehaviour
{
    private float lifespan = 0.2f;
    private MeleeSO meleeSO;

    public void Setup(MeleeSO mSO)
    {
        meleeSO = mSO;
        gameObject.name = meleeSO.name;
    }

    void Update()
    {
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

            health.Damage(meleeSO.damage, meleeSO.armourPen);
        }

        if (!meleeSO.penetration)
        {
            Destroy(gameObject);
        }
    }
}
