using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackroundBehaviour : MonoBehaviour
{

    float previousXPosition;
    float previousYPosition;
    bool firstRun = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (firstRun){
            firstRun = false;
                    previousXPosition = NewBehaviourScript.xPositionTorch;
        previousYPosition = NewBehaviourScript.yPositionTorch;
        }


        float torchXPosition = NewBehaviourScript.xPositionTorch;
        float xDifference = torchXPosition - previousXPosition;
        previousXPosition = torchXPosition;
        float torchYPosition = NewBehaviourScript.yPositionTorch;
        float yDifference = torchYPosition - previousYPosition;
        previousYPosition = torchYPosition;

        Vector2 position = transform.position;
        position.x = position.x + xDifference;
        position.y = position.y + yDifference;
        transform.position = position;

       // sprite.transform.localScale = new Vector3(scale, scale, scale);
       // Gets the local scale of game object
Vector2 objectScale = transform.localScale;


// Sets the local scale of game object
transform.localScale = new Vector2(objectScale.x*0.99f,  objectScale.y*0.99f);

    if (objectScale.x < 1){
        transform.localScale = new Vector2(1,  1);
    }
     else{
 RubyController.maximumDistancePlayer = RubyController.maximumDistancePlayer*0.99f;
     }
    }
}
