using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadybugController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  void FixedUpdate()
  {
    var rigidBody = GetComponent<Rigidbody2D>();
    rigidBody.AddForce(transform.forward);
      
    
  }
}
