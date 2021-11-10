using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadBugController : MonoBehaviour
{
  public bool start = false;
  public float runSpeed = 3;
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    if (!start)
    {
      return;
    }

    transform.Translate(transform.right * runSpeed * Time.deltaTime * -1);

  }
  public void StartMove()
  {
    start = true;
  }
}
