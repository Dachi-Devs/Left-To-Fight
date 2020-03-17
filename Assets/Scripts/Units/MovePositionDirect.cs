using UnityEngine;

public class MovePositionDirect : MonoBehaviour, IMovePos
{
    private Vector3 movePos;

    public void SetMovePosition(Vector3 movePos)
    {
        this.movePos = movePos;
    }

    void Update()
    {
        Vector3 moveDir = (movePos - transform.position).normalized;
        GetComponent<IMoveVelocity>().SetVelocity(moveDir);
    }
}
