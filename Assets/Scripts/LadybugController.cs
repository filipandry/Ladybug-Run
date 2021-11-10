using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LadybugController : MonoBehaviour
{
  [SerializeField] public LayerMask whatIsGround;
  [SerializeField] public LayerMask whatIsEndZone;
  [SerializeField] public LayerMask whatIsDanger;
  public string attentionTag;
  public GameObject attentionObject;
  public float jumpForce = 50;
  public float runSpeed = 10;
  private bool started = false;
  public bool grounded = false;
  public bool doubleJumped = false;
  public bool end = false;
  public bool dead = false;
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
    if (!started || end || dead)
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
    if (collider.IsTouchingLayers(whatIsEndZone.value))
    {
      end = true;
    }
    if (collider.IsTouchingLayers(whatIsDanger.value))
    {
      dead = true;
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
  public void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.gameObject.CompareTag(attentionTag))
    {
      var badBug = collision.gameObject.GetComponentInParent<BadBugController>();
      if(badBug != null)
      {
        badBug.StartMove();
      }
      //near is danger bug
      StartCoroutine(BlinkAttention());
    }
  }
  private IEnumerator BlinkAttention()
  {
    int times = 0;
    while (times <= 3)
    {
      if (attentionObject.activeSelf)
      {
        attentionObject.SetActive(false);
        times++;
      }
      else
      {
        attentionObject.SetActive(true);
      }
      yield return new WaitForSeconds(0.3f);
    }
  }
}
