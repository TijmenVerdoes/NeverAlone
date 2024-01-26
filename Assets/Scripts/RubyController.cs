using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour {
  private float maximumDistanceSquered = 9f;
  private float playerSpeed = 0.1f;

  private void movePlayer() {
    var horizontal = Input.GetAxis("Horizontal");
    var vertical = Input.GetAxis("Vertical");
    Vector2 position = transform.position;
    position.x += playerSpeed * horizontal;
    position.y += playerSpeed * vertical;

    transform.position = position;
  }

  private bool isPlayerInTorch() {
    Vector2 position = transform.position;
    var xDifference = position.x - NewBehaviourScript.xPositionTorch;
    var yDifference = position.y - NewBehaviourScript.yPositionTorch;

    var triangeTotal = xDifference * xDifference + yDifference * yDifference;

    return !(triangeTotal > maximumDistanceSquered);
  }

  private void GetPlayerInTorch() {
    Vector2 position = transform.position;

    position.x = NewBehaviourScript.xPositionTorch;
    position.y = NewBehaviourScript.yPositionTorch;

    transform.position = position;
  }

  // Update is called once per frame
  private void Update() {
    movePlayer();

    if (!isPlayerInTorch()) {
      GetPlayerInTorch();
    }
  }
}
