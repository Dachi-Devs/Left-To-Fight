using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private string spawnTag;

    [SerializeField]
    private GameObject enemyP;
    public static GameObject enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        enemyPrefab = enemyP;
        GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag(spawnTag);
        foreach (GameObject spawnPoint in spawnPoints)
        {
            spawnPoint.GetComponent<SpawnerData>().SpawnEnemy();
        }
    }
}
