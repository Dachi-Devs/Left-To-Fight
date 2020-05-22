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
    }
}
