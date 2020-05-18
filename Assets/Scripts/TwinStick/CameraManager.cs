using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private Camera cam;

    [SerializeField]
    private Transform playerToFollow;

    [SerializeField]
    private Transform levelCorner;

    [SerializeField]
    private float speed;

    [SerializeField]
    private Vector2 minBoundary;
    [SerializeField]
    private Vector2 maxBoundary;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        minBoundary = new Vector2(cam.orthographicSize * 16 / 9, cam.orthographicSize);
        maxBoundary = new Vector2(levelCorner.position.x - cam.orthographicSize * 16 / 9, levelCorner.position.y - cam.orthographicSize);
    }

    // Update is called once per frame
    void Update()
    {
        FollowTarget();
    }

    private void FollowTarget()
    {
        Vector3 camMove = Vector3.Lerp(transform.position, playerToFollow.position, speed * Time.deltaTime);
        camMove = new Vector3(
            Mathf.Clamp(camMove.x, minBoundary.x, maxBoundary.x),
            Mathf.Clamp(camMove.y, minBoundary.y, maxBoundary.y),
            camMove.z);

        transform.position = new Vector3(camMove.x, camMove.y, -10f);
    }
}
