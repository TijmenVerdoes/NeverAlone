using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour {
  // Start is called before the first frame update

  public static float maximumDistancePlayer = 4.5f;
  private float maximumDistanceSquered = 25f;
  private float playerSpeed = 0.1f;
  void Start() {}

  private void movePlayer() {
    float horizontal = Input.GetAxis("Horizontal");
    float vertical = Input.GetAxis("Vertical");
    Vector2 position = transform.position;
    position.x = position.x + playerSpeed * horizontal;
    position.y = position.y + playerSpeed * vertical;
    transform.position = position;
  }

  private bool isPlayerInTorch() {
    Vector2 position = transform.position;
    float xDifference = position.x - NewBehaviourScript.xPositionTorch;
    float yDifference = position.y - NewBehaviourScript.yPositionTorch;

    float triangeTotal = xDifference * xDifference + yDifference * yDifference;

    if (triangeTotal > maximumDistanceSquered) {
      return false;
    }
    return true;
  }

  private void getPlayerInTorch() {


    Vector2 position = transform.position;

    position.x = NewBehaviourScript.xPositionTorch;
    position.y = NewBehaviourScript.yPositionTorch;

    transform.position = position;
  }

  // Update is called once per frame
  void Update() {
        maximumDistanceSquered = maximumDistancePlayer*maximumDistancePlayer;
    movePlayer();

    if (!isPlayerInTorch()) {
      getPlayerInTorch();
    }
  }
}
