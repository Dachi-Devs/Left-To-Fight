using UnityEngine;

public class MoveTransformVelocity : MonoBehaviour, IMoveVelocity
{
    [SerializeField]
    private float moveSpeed;

    private Vector3 velocityVector;
    private Rigidbody2D rb2d;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        if (rb2d == null)
        {
            rb2d = gameObject.AddComponent<Rigidbody2D>();
        }
        rb2d.gravityScale = 0;
        //GetAnimControllerWhenMade
    }

    public void SetVelocity(Vector3 velocityVector)
    {
        this.velocityVector = velocityVector;
    }

    void Update()
    {
        transform.position += velocityVector * moveSpeed * Time.deltaTime;
        //PlayAnimWhenMade
    }
}
