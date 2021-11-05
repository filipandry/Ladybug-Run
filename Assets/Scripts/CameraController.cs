using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
  public GameObject gameObjectToFollow;

  private float deltaX;
  // Start is called before the first frame update
  void Start()
  {
    deltaX = gameObjectToFollow.transform.localPosition.x - transform.localPosition.x;
  }

  // Update is called once per frame
  void Update()
  {
    transform.localPosition = new Vector3(gameObjectToFollow.transform.localPosition.x - deltaX, transform.localPosition.y, transform.localPosition.z);
  }
}