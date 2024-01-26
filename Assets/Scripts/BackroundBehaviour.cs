using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackroundBehaviour : MonoBehaviour
{
    float previousXPosition;
    float previousYPosition;
    bool firstRun = true;

    private void Update()
    {
        if (firstRun)
        {
            firstRun = false;
            previousXPosition = NewBehaviourScript.xPositionTorch;
            previousYPosition = NewBehaviourScript.yPositionTorch;
        }

        var torchXPosition = NewBehaviourScript.xPositionTorch;
        var xDifference = torchXPosition - previousXPosition;
        previousXPosition = torchXPosition;
        var torchYPosition = NewBehaviourScript.yPositionTorch;
        var yDifference = torchYPosition - previousYPosition;
        previousYPosition = torchYPosition;

        Vector2 position = transform.position;
        position.x += xDifference;
        position.y += yDifference;
        transform.position = position;

        // Gets the local scale of game object
        Vector2 objectScale = transform.localScale;


        // Sets the local scale of game object
        transform.localScale = new Vector2(objectScale.x * 0.99f, objectScale.y * 0.99f);

        if (objectScale.x < 1)
        {
            transform.localScale = new Vector2(1, 1);
        }
        else
        {
            RubyController.maximumDistancePlayer *= 0.99f;
        }
    }
}