using UnityEngine;

[CreateAssetMenu(fileName = "New Bullet", menuName = "Gun/Bullet/New Bullet")]
public class BulletSO : ScriptableObject
{
    public float damage;
    public float speedMod;
    public bool penetration;

    public Sprite bulletSprite;
}
