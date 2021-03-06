﻿using UnityEngine;

public class MoveVelocity : MonoBehaviour, IMoveVelocity
{
    private float moveSpeed = 40f;

    private Vector3 velocityVector;
    private Rigidbody2D rb2d;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        if (rb2d == null)
        {
            rb2d = gameObject.AddComponent<Rigidbody2D>();
        }
        //GetAnimControllerWhenMade
    }

    public void SetVelocity(Vector3 velocityVector)
    {
        this.velocityVector = velocityVector;
    }

    void FixedUpdate()
    {
        rb2d.velocity = velocityVector * moveSpeed;

        //PlayAnimWhenMade
    }

    public void SetMoveSpeed(float speed)
    {
        moveSpeed = speed;
    }
}
