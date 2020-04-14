using UnityEngine;

[CreateAssetMenu(fileName = "New Gun", menuName = "Gun/New Gun")]
public class GunSO : ScriptableObject
{
    public BulletSO bulletSO;

    public Vector3 fireOffset;

    public Sprite gunSprite;
}
