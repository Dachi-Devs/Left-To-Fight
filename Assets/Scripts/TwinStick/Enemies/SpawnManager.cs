using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private string spawnTag;

    [SerializeField]
    private GameObject enemyPrefab;
    public static GameObject sEnemyPrefab;

    public float hordeDelay;
    public EnemySO hordeEnemySO;

    // Start is called before the first frame update
    void Start()
    {
        sEnemyPrefab = enemyPrefab;
        SpawnEnemies();
        FindObjectOfType<LevelManager>().OnHordeActive += LevelManager_OnHordeActive;
    }

    private void SpawnEnemies()
    {
        GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag(spawnTag);
        foreach (GameObject spawnPoint in spawnPoints)
        {
            spawnPoint.GetComponent<SpawnerData>().SpawnEnemy();
        }
    }

    private void LevelManager_OnHordeActive(object sender, System.EventArgs e)
    {
        SetupHorde();
    }

    private void SetupHorde()
    {
        GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag(spawnTag);
        foreach (GameObject spawnPoint in spawnPoints)
        {
            spawnPoint.GetComponent<SpawnerData>().SetEnemyType(hordeEnemySO);
        }

        SpawnHorde();
    }

    private void SpawnHorde()
    {
        SpawnEnemies();
        StartCoroutine(HordeDelay());
    }

    private IEnumerator HordeDelay()
    {
        Debug.Log("Waiting for delay");
        yield return new WaitForSeconds(hordeDelay);
        SpawnHorde();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
            SetupHorde();
    }
}
