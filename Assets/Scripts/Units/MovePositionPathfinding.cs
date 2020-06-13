using System.Collections.Generic;
using UnityEngine;

public class MovePositionPathfinding : MonoBehaviour, IMovePos
{
    [SerializeField]
    private List<Vector3> pathVectorList;
    [SerializeField]
    private int pathIndex = 0;
    private IMoveVelocity movement;
    private IRotate rotation;
    [SerializeField]
    private float reachedTargetDistance;


    void Awake()
    {
        movement = GetComponent<IMoveVelocity>();
        rotation = GetComponent<IRotate>();
    }

    public void SetMovePosition(Vector3 targetPos)
    {
        pathIndex = 0;
        pathVectorList = Pathfinding.instance.FindPath(GetPosition(), targetPos);

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
            float distanceToTaget = Vector3.Distance(transform.position, targetPosition);
            if (distanceToTaget > reachedTargetDistance)
            {
                if (distanceToTaget > 1f)
                    rotation.SetDirection(targetPosition);
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
        GetComponent<IController>().TargetReached();
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }
}
