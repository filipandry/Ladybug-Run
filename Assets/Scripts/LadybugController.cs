using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LadybugController : MonoBehaviour
{
  [SerializeField] public LayerMask whatIsGround;
  public float jumpForce = 50;
  public float runSpeed = 10;
  private bool started = false;
  public bool grounded = false;
  public bool doubleJumped = false;
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
    if (!started)
    {
      return;
    }
    transform.Translate(transform.right * runSpeed * Time.deltaTime);

    var collider = GetComponent<Collider2D>();
    grounded = collider.IsTouchingLayers(whatIsGround.value);
    if (grounded)
    {
      doubleJumped = false;
    }
  }
  public void Jump(InputAction.CallbackContext context)
  {
    if (started)
    {
      if(context.phase != InputActionPhase.Started)
      {
        return;
      }
      if (grounded || !doubleJumped)
      {
        if (!grounded)
        {
          doubleJumped = true;
        }
        var rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.AddForce(transform.up * jumpForce);
        
      }
    }
    else
    {
      started = true;
    }
  }
}
