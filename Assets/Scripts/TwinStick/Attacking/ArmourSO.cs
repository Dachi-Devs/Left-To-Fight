using UnityEngine;

[CreateAssetMenu(fileName = "New Armour", menuName = "Items/Armour/New Armour")]
public class ArmourSO : ScriptableObject
{
    public string armourName;

    public float armourCond;
    public float armourResist;
}