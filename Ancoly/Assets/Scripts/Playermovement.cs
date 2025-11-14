using UnityEngine;
using UnityEngine.Rendering;

public class NewMonoBehaviourScript : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 moveInput;
    Vector2 currentVelocity;

    public float walkingSpeed = 5;
    public float SprintingSpeed = 5f;
    public float acceleration = 10f;
    public float deceleration = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput.Normalize();
    }
    void FixedUpdate()
    {
        float movementSpeed = Input.GetKey(KeyCode.LeftShift) ? SprintingSpeed : walkingSpeed;
        Vector2 targetVelocity = moveInput * movementSpeed;
        float accelRate = (moveInput.magnitude > 0) ? acceleration : deceleration;
        currentVelocity = Vector2.Lerp(rb.linearVelocity, targetVelocity, accelRate * Time.fixedDeltaTime);
        rb.linearVelocity = currentVelocity;
    }
}
