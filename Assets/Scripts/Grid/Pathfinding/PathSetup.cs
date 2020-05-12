using System.Collections;
using System.Collections.Generic;
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


    void Start()
    {
        pathfinding = new Pathfinding(gridX, gridY, transform.position);
        if (pathfinderVisual != null)
            pathfinderVisual.SetGrid(pathfinding.GetGrid());
    }
}
