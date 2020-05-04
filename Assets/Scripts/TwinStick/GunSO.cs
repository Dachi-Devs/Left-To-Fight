using UnityEngine;

[CreateAssetMenu(fileName = "New Gun", menuName = "Gun/New Gun")]
public class GunSO : ScriptableObject
{
    public BulletSO bulletSO;

    public float fireRate;

    public float fireOffset;

    public Sprite gunSprite;
}
