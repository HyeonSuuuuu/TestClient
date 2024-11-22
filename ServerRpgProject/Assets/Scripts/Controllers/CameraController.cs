using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Transform clampMin, clampMax;
    public Camera cam;
    public float lerpSpeed = 1.0f;

    private float halfWidth, halfHeight;
    private Vector3 offset;
    private Vector3 targetPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        clampMin.parent = null;
        clampMax.parent = null;
        cam = GetComponent<Camera>();
        halfHeight = cam.orthographicSize;
        halfWidth = cam.orthographicSize * cam.aspect;

        if (target == null)
        {
            target = FindAnyObjectByType<PlayerController>().transform;
            if (target == null)
            {
                return;
            }
        }
        this.transform.position = new Vector3(target.position.x, target.position.y, this.transform.position.z);
        offset = transform.position - target.position;
    }

    public void BorderSetting(Transform clampMin, Transform clampMax)
    {
        this.clampMin = clampMin;
        this.clampMax = clampMax;
    }



    // Update is called once per frame
    void Update()
    {
        if (target == null) return;

        targetPos =  target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPos, lerpSpeed * Time.deltaTime);

        Vector3 clampPosition = transform.position;
        clampPosition.x = Mathf.Clamp(clampPosition.x, clampMin.position.x + halfWidth, clampMax.position.x - halfWidth);
        clampPosition.y = Mathf.Clamp(clampPosition.y, clampMin.position.y + halfHeight, clampMax.position.y - halfHeight);
        transform.position = clampPosition;
    }
}
