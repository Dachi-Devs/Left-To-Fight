using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public enum CamTargetMode
    { 
        topDown,
        baseManage,
        cutscene
    }

    [SerializeField]
    private CamTargetMode targetMode; 

    private Camera cam;

    [SerializeField]
    private Transform targetToFollow;

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
        switch (targetMode)
        {
            case CamTargetMode.topDown:        
                minBoundary = new Vector2(cam.orthographicSize * 16 / 9, cam.orthographicSize);
                maxBoundary = new Vector2(FindObjectOfType<PathSetup>().gridMax.x - cam.orthographicSize * 16 / 9, FindObjectOfType<PathSetup>().gridMax.y - cam.orthographicSize);
                break;
            case CamTargetMode.baseManage:
                break;
            case CamTargetMode.cutscene:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (targetMode)
        {
            case CamTargetMode.topDown:
                FollowTarget();
                break;
            case CamTargetMode.baseManage:
                break;
            case CamTargetMode.cutscene:
                break;
        }
    }

    private void FollowTarget()
    {
        if (targetToFollow != null)
        {
            Vector3 camMove = Vector3.Lerp(transform.position, targetToFollow.position, speed * Time.deltaTime);
            camMove = new Vector3(
                Mathf.Clamp(camMove.x, minBoundary.x, maxBoundary.x),
                Mathf.Clamp(camMove.y, minBoundary.y, maxBoundary.y),
                camMove.z);

            transform.position = new Vector3(camMove.x, camMove.y, -10f);
        }
    }
}
