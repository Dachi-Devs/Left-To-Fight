using UnityEngine;

public class PathSetup : MonoBehaviour
{
    [SerializeField]
    private PathfinderVisual pathfinderVisual;
    public Pathfinding pathfinding { get; private set; }

    [SerializeField]
    private int gridX;
    [SerializeField]
    private int gridY;
    [SerializeField]
    private float cellSize;

    private Vector2 originPos;

    [SerializeField]
    public Vector2 gridMax;

    void Awake()
    {
        gridMax = new Vector2(gridX * cellSize, gridY * cellSize);
    }

    void Start()
    {
        //originPos = new Vector2(transform.position.x - gridX / 2 * cellSize, transform.position.y - gridY / 2 * cellSize);
        pathfinding = new Pathfinding(gridX, gridY, cellSize, originPos);
        if (pathfinderVisual != null)
            pathfinderVisual.SetGrid(pathfinding.GetGrid());
        SpawnBorder();
    }

    private void SpawnBorder()
    {
        GameObject g = new GameObject();
        g.AddComponent<BoxCollider2D>();
        SpawnAtLocation(g, new Vector2(gridX * cellSize, 8), new Vector2(gridX * cellSize / 2, -4));
        SpawnAtLocation(g, new Vector2(gridX * cellSize, 8), new Vector2(gridX * cellSize / 2, gridY * cellSize + 4));
        SpawnAtLocation(g, new Vector2(8, gridY * cellSize), new Vector2(-4, gridY * cellSize / 2));
        SpawnAtLocation(g, new Vector2(8, gridY * cellSize), new Vector2(gridX * cellSize + 4, gridY * cellSize / 2));
        Destroy(g);
    }

    private void SpawnAtLocation(GameObject barrier, Vector2 scale, Vector2 position)
    {
        GameObject b = Instantiate(barrier, position, Quaternion.identity);
        b.transform.localScale = scale;
        b.name = "Barrier";
    }
}
