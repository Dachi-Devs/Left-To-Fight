using UnityEngine;

public class UnrestSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private string spawnTag;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag(spawnTag);
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            SpawnZombie(spawnPoints[i].transform);
        }
    }

    void SpawnZombie(Transform spawnPoint)
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
