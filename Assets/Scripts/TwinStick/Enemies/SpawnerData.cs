using System.Collections;
using UnityEngine;

public class SpawnerData : MonoBehaviour
{
    [SerializeField]
    private EnemySO enemyType;

    private EnemySO defaultEnemyType;

    private void Start()
    {
        defaultEnemyType = enemyType;
    }

    public void SpawnEnemy()
    {
        GameObject enemy = Instantiate(SpawnManager.sEnemyPrefab, transform.position, Quaternion.identity);
        enemy.GetComponent<EnemyFSM>().SetEnemyType(enemyType);
    }

    public void SetEnemyType(EnemySO _enemyType)
    {
        enemyType = _enemyType;
    }
}
