using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public static float xPositionTorch = 0;
    public static float yPositionTorch = 0;

    bool toTheRight = true;
    bool toTheTop = true;

    short lightHorizontalMovement = 5;
    short lightVerticalMovement = 2;
    // Start is called before the first frame update
    void Start()
    {
    //            Vector2 position = transform.position;
    //    xPositionTorch = position.x;
    //    yPositionTorch = position.y;
    //            Debug.Log(xPositionTorch);
    //     Debug.Log(yPositionTorch);

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;

        //        Debug.Log(xPositionTorch);
        // Debug.Log(yPositionTorch); 

        
    //            Vector2 position = transform.position;
if (toTheRight){
    position.x = position.x + 0.0101f;
        if (position.x > lightHorizontalMovement){
            toTheRight = false;
        }
}
else{
        position.x = position.x - 0.0101f;
        if (position.x < lightHorizontalMovement * -1){
            toTheRight = true;
        }
}


if (toTheTop){
    position.y = position.y + 0.0151f;
        if (position.y > lightVerticalMovement){
            toTheTop = false;
        }
}
else{
        position.y = position.y - 0.00101f;
        if (position.y < lightVerticalMovement * -1){
            toTheTop = true;
        }
}

       //position.x = position.x + 0.001f;
       //position.y = position.y + 0.001f;

              xPositionTorch = position.x;
       yPositionTorch = position.y;


       transform.position = position;
    }



    // float getXPosition(){
    //     return yPositionTorch;
    // }

}
