using UnityEngine;

public class ZombieFSM : MonoBehaviour, IController
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

    private enum State
    {
        roaming,
        attacking,
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
                    break;    
                }
            case State.attacking:
                {

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
        StartIdle();
    }
}
