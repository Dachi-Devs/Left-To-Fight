using UnityEngine;

public class SpawnerData : MonoBehaviour
{
    [SerializeField]
    private EnemySO enemyType;

    public void SpawnEnemy()
    {
        GameObject enemy = Instantiate(SpawnManager.enemyPrefab, transform.position, Quaternion.identity);
        enemy.GetComponent<EnemyFSM>().SetEnemyType(enemyType);
    }
}
