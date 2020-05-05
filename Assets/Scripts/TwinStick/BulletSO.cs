using UnityEngine;

[CreateAssetMenu(fileName = "New Bullet", menuName = "Gun/Bullet/New Bullet")]
public class BulletSO : ScriptableObject
{
    public string bulletName;
    public Sprite bulletSprite;
    public float damage;
    public float armourPen;
    public float speedMod;
    public bool penetration;
}
