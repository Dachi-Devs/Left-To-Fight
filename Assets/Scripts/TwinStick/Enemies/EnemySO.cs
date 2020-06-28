using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemies/New Enemy")]
public class EnemySO : ScriptableObject
{
    public float attackRange;
    public float targetRange;
    public float moveSpeed;

    public Color tint;

    public DropTableSO dropTable;
}
