using UnityEngine;

public class EnemyFSM : MonoBehaviour, IController
{
    private IMovePos movement;

    private Vector3 startPos;
    [SerializeField]
    private Vector3 roamPos;

    [SerializeField]
    private float idleMax;
    [SerializeField]
    private float idleTimer;
    private bool idle;

    [SerializeField]
    private float targetRange;

    [SerializeField]
    private Transform currentTarget;

    private enum State
    {
        roaming,
        chasing,
    }

    [SerializeField]
    private State state;

    void Awake()
    {
        movement = GetComponent<IMovePos>();
    }

    void Start()
    {
        state = State.roaming;
        idleTimer = idleMax;
        startPos = transform.position;
        roamPos = GetRoamingArea();
        movement.SetMovePosition(roamPos);

        currentTarget = FindNearestTarget();
    }

    void Update()
    {
        switch (state)
        {
            case State.roaming:
                {        
                    if (idle == true)
                    {
                        if (idleTimer > 0)
                            idleTimer -= Time.deltaTime;
                        else
                        {
                            idle = false;
                            NewTarget();
                        }
                    }
                    currentTarget = FindNearestTarget();
                    break;    
                }
            case State.chasing:
                {
                    if (currentTarget == null)
                    {
                        state = State.roaming;
                        break;
                    }
                    else
                    {
                        movement.SetMovePosition(currentTarget.position);
                        if (IsChaseBroken())
                        {
                            currentTarget = null;
                        }
                    }

                    break;
                }
        }
    }
    private void NewTarget()
    {
        roamPos = GetRoamingArea();
        movement.SetMovePosition(roamPos);
    }


    private Vector3 GetRoamingArea()
    {
        Vector3 roamTarget;
        roamTarget = startPos + RandomDirection() * Random.Range(10f, 30f);
        if (roamTarget.x < 0)
            roamTarget.x = 0;
        if (roamTarget.y < 0)
            roamTarget.y = 0;
        return roamTarget;
    }
    private Vector3 RandomDirection()
    {
        Vector3 target;
        target = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        return target;
    }

    private void StartIdle()
    {
        idleTimer = idleMax;
        idle = true;
    }

    //Call received by Pathfinding
    public void TargetReached()
    {
        switch (state)
        {
            case State.roaming:
                StartIdle();
                break;

            case State.chasing:
                break;
        }
    }

    private Transform FindNearestTarget()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Human");
        Transform closestTarget = targets[0].transform;

        for (int i = 1; i < targets.Length; i++)
        {
            if (Vector3.Distance(targets[i].transform.position, transform.position) < Vector3.Distance(closestTarget.position, transform.position))
            {
                closestTarget = targets[i].transform;
            }
        }

        if (Vector3.Distance(closestTarget.position, transform.position) < targetRange)
        {
            state = State.chasing;
            return closestTarget;
        }
        else
        {

            return null;
        }
    }

    private bool IsChaseBroken()
    {
        return (Vector3.Distance(transform.position, currentTarget.position)) > (targetRange * 1.2f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        //Gizmos.DrawWireSphere(transform.position, targetRange);
    }
}
