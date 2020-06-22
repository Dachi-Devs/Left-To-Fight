using UnityEngine;

[CreateAssetMenu(fileName = "New Melee", menuName = "Melee/New Melee")]
public class MeleeSO : ScriptableObject
{
    public string meleeName;
    public float damage;
    public float armourPen;
    public bool penetration;
}
