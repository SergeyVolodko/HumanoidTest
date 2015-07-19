using UnityEngine;

public class MainCamera : MonoBehaviour
{

    public Transform Fighter1;
    public Transform Fighter2;

    private Transform camera;

    private float minSize = 3f;
    private float maxSize = 10f;

    void Start()
    {
        camera = Camera.main.transform;
    }

    void Update()
    {
        var vectorBetweenFighters = Fighter2.position - Fighter1.position;

        var middlePoint = Fighter1.position + 0.5f * vectorBetweenFighters;

        var distance = vectorBetweenFighters.magnitude;
        
        Camera.main.orthographicSize = CalculateCameraSize(distance);
        camera.position = new Vector3(ApplyXLimits(middlePoint.x),
                                      ApplyYLimits(middlePoint.y),
                                      Camera.main.transform.position.z);
    }

    private float ApplyXLimits(float x)
    {
        float leftLimit = -(maxSize - minSize - 1f);
        if (x <= leftLimit)
        {
            return leftLimit;
        }
        float rightLimit = maxSize - minSize - 1f;
        if (x >= rightLimit)
        {
            return rightLimit;
        }

        return x;
    }

    private float ApplyYLimits(float y)
    {
        float upLimit = maxSize - minSize + 1f;
        if (y >= upLimit)
        {
            return upLimit;
        }
        float downLimit = minSize;
        if (y <= downLimit)
        {
            return downLimit;
        }

        return y;
    }

    private float CalculateCameraSize(float distanceBetweenFighters)
    {
        float distanceMargin = 0.5f;

        var size = 0.5f * distanceBetweenFighters + distanceMargin;

        if (size < minSize)
        {
            size = minSize;
        }
        else if (size > maxSize)
        {
            size = maxSize;
        }

        return size;
    }
}
