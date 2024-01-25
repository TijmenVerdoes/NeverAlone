using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {
  public static float xPositionTorch = 0;
  public static float yPositionTorch = 0;

  private bool toTheRight = true;
  private bool toTheTop = true;

  private short lightHorizontalMovement = 5;
  private short lightVerticalMovement = 2;

  private float torchSpeedHorizontal = 0.01f;
  private float torchSpeedVertical = 0.005f;
  // Start is called before the first frame update
  void Start() {}

  private void moveSideways() {
    Vector2 position = transform.position;
    if (toTheRight) {
      position.x = position.x + torchSpeedHorizontal;
      if (position.x > lightHorizontalMovement) {
        toTheRight = false;
      }
    } else {
      position.x = position.x - torchSpeedHorizontal;
      if (position.x < lightHorizontalMovement * -1) {
        toTheRight = true;
      }
    }

    xPositionTorch = position.x;
    transform.position = position;
  }

  private void moveHorizontal() {
    Vector2 position = transform.position;

    if (toTheTop) {
      position.y = position.y + torchSpeedVertical;
      if (position.y > lightVerticalMovement) {
        toTheTop = false;
      }
    } else {
      position.y = position.y - torchSpeedVertical;
      if (position.y < lightVerticalMovement * -1) {
        toTheTop = true;
      }
    }
    yPositionTorch = position.y;
    transform.position = position;
  }

  // Update is called once per frame
  void Update() {
    moveSideways();
    moveHorizontal();
  }
}