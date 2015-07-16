﻿using UnityEngine;

public class MainCamera : MonoBehaviour {

    public Transform Fighter1;
    public Transform Fighter2;
        

    void Start()
    {
    }

    void Update()
    {
        var vectorBetweenFighters = Fighter2.position - Fighter1.position;

        var middlePoint = Fighter1.position + 0.5f * vectorBetweenFighters;

        var distance = vectorBetweenFighters.magnitude;
        
        Camera.main.orthographicSize = CalculateCameraSize(distance);
        Camera.main.transform.position = new Vector3(middlePoint.x, 
                                                     middlePoint.y,
                                                     Camera.main.transform.position.z);
    }

    private float CalculateCameraSize(float distanceBetweenFighters)
    {
        float minSize = 0.5f;
        float maxSize = 5f;
        float distanceMargin = 0.5f;

        var size = 0.5f*distanceBetweenFighters + distanceMargin;
        
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