using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePositionPathfinding : MonoBehaviour, IMovePos
{
    [SerializeField]
    private List<Vector3> pathVectorList;
    [SerializeField]
    private int pathIndex = 0;
    private IMoveVelocity movement;
    [SerializeField]
    private float reachedTargetDistance;

    void Awake()
    {
        movement = GetComponent<IMoveVelocity>();
    }

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
            if (Vector3.Distance(transform.position, targetPosition) > reachedTargetDistance)
            {
                Vector3 moveDir = (targetPosition - transform.position).normalized;
                movement.SetVelocity(moveDir);
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
        movement.SetVelocity(Vector3.zero);
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }
}
