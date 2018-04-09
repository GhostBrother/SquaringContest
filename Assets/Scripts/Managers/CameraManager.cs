using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour { //  a prototype camera controller, will be modified to have several players on a future date. 

    public float dampTime = 0.2f;
    public float screenEdgeBuffer = 4f;
    public float MinSize = 6.5f;
    public Transform[] Targets;

    private Camera Camera;
    private float ZoomSpeed;
    private Vector3 MoveVelocity;
    Vector3 DesiredPosition;

    private void Awake()
    {
        Camera = GetComponentInChildren<Camera>();
    }

    private void FixedUpdate()
    {
        Move();
        Zoom();
    }

    private void Move()
    {
        FindAveragePosition();

        transform.position = Vector3.SmoothDamp(transform.position, DesiredPosition, ref MoveVelocity, dampTime);
    }

    private void FindAveragePosition()
    {
        Vector3 averagePos = new Vector3();
        int numTargets = 0;
        
        for (int i = 0; i<Targets.Length; i++)
        {
            if (!Targets[i].gameObject.activeSelf)
                continue;

            averagePos += Targets[i].position;
            numTargets++;
        }

        if (numTargets > 0)
            averagePos /= numTargets;

        averagePos.y = transform.position.y;

        DesiredPosition = averagePos;
    }

    private void Zoom()
    {
        float requiredSize = findRequiredSize();
        Camera.orthographicSize = Mathf.SmoothDamp(Camera.orthographicSize, requiredSize, ref ZoomSpeed, dampTime);
    }

    private float findRequiredSize()
    {
        Vector3 desiredLocalPos = transform.InverseTransformDirection(DesiredPosition);

        float size = 0f;

        for (int i = 0; i < Targets.Length; i++)
        {
            if (!Targets[i].gameObject.activeSelf)
                continue;

            Vector3 targetLocalPos = transform.InverseTransformDirection(Targets[i].position);

            Vector3 desiredPosToTarget = targetLocalPos - desiredLocalPos;

            size = Mathf.Max(size, Mathf.Abs(desiredPosToTarget.y));

            size = Mathf.Max(size, Mathf.Abs(desiredPosToTarget.x) / Camera.aspect);
        }
        size += screenEdgeBuffer;
        size = Mathf.Max(size, MinSize);

        return size;
    }

    public void SetStartPositionAndSize()
    {
        FindAveragePosition();

        transform.position = DesiredPosition;

        Camera.orthographicSize = findRequiredSize();
    }
    
}
