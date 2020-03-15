using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GathererAI : MonoBehaviour
{
    private enum State
    {
        Idle,
        MovingToResouce,
        GatheringResource,
        MovingToStorage,
    }

    private IUnit unit;
    private State state;
    private Transform resourceNode;
    private Transform storageNode;
    private int resourceInv;


    private void Awake()
    {
        unit = gameObject.GetComponent<IUnit>();
        state = State.Idle;

        //unit.MoveTo(objectGatherTransform.position, 10f, () =>
        //{
        //    unit.PlayAnimationWorking(objectGatherTransform.position, () =>
        //    {
        //        unit.MoveTo(storageTransform.position, 5f, null);
        //    });
        //});
    }

    void Update()
    {
        switch (state)
        {
            case State.Idle:
                resourceNode = ResourceHandler.GetResource_Static();
                state = State.MovingToResouce;
                break;
            case State.MovingToResouce:
                if (unit.IsIdle())
                {
                    unit.MoveTo(resourceNode.position, 10f, () =>
                    {
                        state = State.GatheringResource;
                    });
                }
                break;
            case State.GatheringResource:
                if (unit.IsIdle())
                {
                    if (resourceInv > 0)
                    {
                        storageNode = ResourceHandler.GetStorage_Static();
                        state = State.MovingToStorage;
                    }

                    else
                    {
                        unit.PlayAnimationWorking(resourceNode.position, () =>
                        {
                            resourceInv++;
                        });
                    }
                }
                break;
            case State.MovingToStorage:
                if (unit.IsIdle())
                {
                    unit.MoveTo(storageNode.position, 10f, () =>
                    {
                        resourceInv = 0;
                        state = State.Idle;
                    });
                }
                break;
        }
    }
}
