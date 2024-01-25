using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RubyController : MonoBehaviour
{
    // Start is called before the first frame update

    float maximumDistance = 3.0f;
    float maximumDistanceSquered = 9f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float horizontal = Input.GetAxis("Horizontal");
       float vertical = Input.GetAxis("Vertical");
        // Debug.Log(horizontal);
        // Debug.Log(vertical);
       Vector2 position = transform.position;
       position.x = position.x + 0.1f * horizontal;
       position.y = position.y + 0.1f * vertical;
       
        float xDifference = position.x - NewBehaviourScript.xPositionTorch;
        float yDifference = position.y - NewBehaviourScript.yPositionTorch;

        float triangeTotal = xDifference * xDifference + yDifference * yDifference;

        if (triangeTotal > maximumDistanceSquered){
                  position.x = NewBehaviourScript.xPositionTorch;
        position.y = NewBehaviourScript.yPositionTorch;
        }





      // if ( Mathf.Abs(position.x - NewBehaviourScript.xPositionTorch)    > maximumDistance ){
      //   position.x = NewBehaviourScript.xPositionTorch;
      //   position.y = NewBehaviourScript.yPositionTorch;
      // }
      // if ( Mathf.Abs(position.y - NewBehaviourScript.yPositionTorch)    > maximumDistance ){
      //   position.x = NewBehaviourScript.xPositionTorch;
      //   position.y = NewBehaviourScript.yPositionTorch;
      // }





transform.position = position;

    }
}
