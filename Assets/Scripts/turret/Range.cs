using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range : MonoBehaviour
{
    public LineRenderer circleRenderer; 
    void Start()
    {
        DrawCircle(1000, 15f);
    }

    void DrawCircle(int steps,float radius)
    {
        circleRenderer.positionCount = steps;
        for (int currentStep = 0; currentStep < steps;currentStep ++)
        {
            float circumferenceProgress = (float)currentStep / steps;
            float currentRadian = circumferenceProgress * 2 * Mathf.PI;
            float xScaled = Mathf.Cos(currentRadian);
            float yScaled = Mathf.Sin(currentRadian);

            float x = xScaled * radius;
            float y = yScaled * radius;

            Vector3 currentPosition = new Vector3(x, 0, y);
            circleRenderer.SetPosition(currentStep,transform.position + currentPosition);
        }
    }
}
