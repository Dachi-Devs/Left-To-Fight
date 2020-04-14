using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private Transform firePosition;

    private GunSO gunSO;

    public GunSO defaultGunSO;

    void Start()
    {
        Setup(defaultGunSO);
    }

    private void Setup(GunSO gunSO)
    {
        this.gunSO = gunSO;
        GetComponentInChildren<SpriteRenderer>().sprite = gunSO.gunSprite;

        firePosition.localPosition = gunSO.fireOffset;
    }

    public void FireBullet()
    {
        Bullet bullet = Instantiate(bulletPrefab, firePosition.position, firePosition.rotation).GetComponent<Bullet>();
        bullet.Setup(gunSO.bulletSO);
    }
}
