using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public static float xPositionTorch = 0;
    public static float yPositionTorch = 0;

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
       xPositionTorch = position.x;
       yPositionTorch = position.y;
        //        Debug.Log(xPositionTorch);
        // Debug.Log(yPositionTorch); 

        
    //            Vector2 position = transform.position;
    //    position.x = position.x + 0.1f;
    //    position.y = position.y + 0.1f;
    //    transform.position = position;
    }



    // float getXPosition(){
    //     return yPositionTorch;
    // }

}
