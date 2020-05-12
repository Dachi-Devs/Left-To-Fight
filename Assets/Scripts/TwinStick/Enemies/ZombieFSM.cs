using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieFSM : MonoBehaviour
{
    private IMovePos movement;

    private Vector3 startPos;
    [SerializeField]
    private Vector3 roamPos;

    [SerializeField]
    private float idleMax;
    private float idleTimer;

    private enum State
    {
        idle,
        roaming,
    }

    private State state;

    void Awake()
    {
        movement = GetComponent<IMovePos>();
    }

    void Start()
    {
        state = State.idle;
        idleTimer = idleMax;
        startPos = transform.position;
        roamPos = GetRoamingArea();
        movement.SetMovePosition(roamPos);
    }

    void Update()
    {

        float targetDistance = 1f;
        if (Vector3.Distance(transform.position, roamPos) < targetDistance)
        {
            Debug.Log("At Target");
            roamPos = GetRoamingArea();
            movement.SetMovePosition(roamPos);
        }

        if (idleTimer > 0)
            idleTimer -= Time.deltaTime;
    }

    private Vector3 GetRoamingArea()
    {
        Vector3 roamTarget;
        roamTarget = startPos + RandomDirection() * Random.Range(10f, 30f);
        return roamTarget;
    }
    private Vector3 RandomDirection()
    {
        return new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }

}
