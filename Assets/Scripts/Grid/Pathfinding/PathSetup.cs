using UnityEngine;

public class PathSetup : MonoBehaviour
{
    [SerializeField]
    private PathfinderVisual pathfinderVisual;
    private Pathfinding pathfinding;

    [SerializeField]
    private int gridX;
    [SerializeField]
    private int gridY;
    [SerializeField]
    private float cellSize;


    void Start()
    {
        pathfinding = new Pathfinding(gridX, gridY, cellSize, transform.position);
        if (pathfinderVisual != null)
            pathfinderVisual.SetGrid(pathfinding.GetGrid());
    }
}
