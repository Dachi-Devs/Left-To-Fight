﻿using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;


public class PathTest : MonoBehaviour
{
    [SerializeField]
    private PathfinderVisual pathfinderVisual;
    [SerializeField]
    private PathFollower pathFollower;
    private Pathfinding pathfinding;

    void Start()
    {
        pathfinding = new Pathfinding(10, 10);
        pathfinderVisual.SetGrid(pathfinding.GetGrid());
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseWorldPos = UtilsClass.GetMouseWorldPosition();
            pathfinding.GetGrid().GetXY(mouseWorldPos, out int x, out int y);
            List<PathNode> path = pathfinding.FindPath(0, 0, x, y);
            //if (path != null)
            //{
            //    for (int i = 0; i < path.Count - 1; i++)
            //    {
            //        Debug.DrawLine(new Vector3(path[i].x, path[i].y) * 10f + Vector3.one * 5f, new Vector3(path[i+1].x, path[i+1].y) * 10f + Vector3.one * 5f, Color.green, 3f);
            //    }
            //}
            pathFollower.SetTargetPosition(mouseWorldPos);
        }

        if (Input.GetMouseButtonDown(1))
        {
            Vector3 mouseWorldPos = UtilsClass.GetMouseWorldPosition();
            pathfinding.GetGrid().GetXY(mouseWorldPos, out int x, out int y);
            pathfinding.GetNode(x, y).SetIsWalkable(!pathfinding.GetNode(x, y).isWalkable);
        }
    }
}
