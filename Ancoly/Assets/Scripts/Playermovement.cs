using UnityEngine;
using UnityEngine.Rendering;

public class NewMonoBehaviourScript : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    Vector2 moveInput;
    Vector2 currentVelocity;
    Animator animator;

    public float movementSpeed = 5;
    public float acceleration = 10f;
    public float deceleration = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput.Normalize();
        if (moveInput.x < 0)
        {
            spriteRenderer.flipX = true;
        }

        else if (moveInput.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        bool isWalking = moveInput.sqrMagnitude > 0.01f;
        if (isWalking)
        {
            animator.enabled = true;
        }
        else
        {
            animator.enabled = false;
        }
    }
    void FixedUpdate()
    {
        Vector2 targetVelocity = moveInput * movementSpeed;
        float accelRate = (moveInput.magnitude > 0) ? acceleration : deceleration;
        currentVelocity = Vector2.Lerp(rb.linearVelocity, targetVelocity, accelRate * Time.fixedDeltaTime);
        rb.linearVelocity = currentVelocity;
    }
}
