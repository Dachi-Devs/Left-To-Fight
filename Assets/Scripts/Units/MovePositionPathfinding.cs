using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePositionPathfinding : MonoBehaviour, IMovePos
{
    private List<Vector3> pathVectorList;
    private int pathIndex = -1;

    public void SetMovePosition(Vector3 targetPos)
    {
        pathIndex = 0;
        pathVectorList = Pathfinding.instance.FindPath(GetPosition(), targetPos);

        foreach (Vector3 v in pathVectorList)
        {
            Debug.Log(v);
        }

        if (pathVectorList != null && pathVectorList.Count > 1)
        {
            pathVectorList.RemoveAt(0);
        }
    }

    void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        if (pathVectorList != null)
        {
            Vector3 targetPosition = pathVectorList[pathIndex];
            if (Vector3.Distance(transform.position, targetPosition) > 0.1f)
            {
                Vector3 moveDir = (targetPosition - transform.position).normalized;
                float distanceBefore = Vector3.Distance(transform.position, targetPosition);
                GetComponent<IMoveVelocity>().SetVelocity(moveDir);
            }
            else
            {
                pathIndex++;
                if (pathIndex >= pathVectorList.Count)
                {
                    StopMoving();
                }
            }
        }
    }

    private void StopMoving()
    {
        pathVectorList = null;
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }
}
