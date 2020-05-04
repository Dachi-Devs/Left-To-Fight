using UnityEngine;

public class GunController : MonoBehaviour, IAttack
{
    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private Transform firePosition;

    private GunSO gunSO;

    [SerializeField]
    private GunSO defaultGunSO;

    private float cooldown;

    private bool triggerPulled;

    void Start()
    {
        Setup(defaultGunSO);
        cooldown = gunSO.fireRate;
    }

    private void Setup(GunSO gunSO)
    {
        this.gunSO = gunSO;
        GetComponentInChildren<SpriteRenderer>().sprite = gunSO.gunSprite;

        firePosition.localPosition = new Vector3(0, gunSO.fireOffset, 0);
    }

    public void StartAttack() => triggerPulled = true;
    public void EndAttack() => triggerPulled = false;

    void Update()
    {
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }

        if (triggerPulled)
        {
            if (cooldown <= 0)
            {
                FireBullet();
                cooldown = gunSO.fireRate;
            }
        }
    }

    public void FireBullet()
    {
        Bullet bullet = Instantiate(bulletPrefab, firePosition.position, firePosition.rotation).GetComponent<Bullet>();
        bullet.Setup(gunSO.bulletSO);
    }
}
