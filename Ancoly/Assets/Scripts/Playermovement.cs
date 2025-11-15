using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    Vector2 moveInput;
    Vector2 currentVelocity;
    Animator animator;

    public float movementSpeed = 5;
    public float acceleration = 10f;
    public float deceleration = 10f;
    public Vector3 leftRotation;
    public Vector3 rightRotation;
    public Light2D lighter;

    [SerializeField]
    private SoundEffectPlayer soundEffectPlayer;

    [SerializeField]
    private float stepInterval = 0.4f; // Zeit zwischen Schritten

    private float currentStepTime;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();
        lighter.gameObject.SetActive(false);
        currentStepTime = 0f;
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
            UpdateLighterRotation(true);
        }

        else if (moveInput.x > 0)
        {
            spriteRenderer.flipX = false;
            UpdateLighterRotation(false);
        }
        bool isWalking = moveInput.sqrMagnitude > 0.01f;
        if (isWalking)
        {
            animator.enabled = true;
            HandleStepSound();
        }
        else
        {
            animator.enabled = false;
            currentStepTime = 0f;
        }
    }

    void FixedUpdate()
    {
        Vector2 targetVelocity = moveInput * movementSpeed;
        float accelRate = (moveInput.magnitude > 0) ? acceleration : deceleration;
        currentVelocity = Vector2.Lerp(rb.linearVelocity, targetVelocity, accelRate * Time.fixedDeltaTime);
        rb.linearVelocity = currentVelocity;
    }

    private void HandleStepSound()
    {
        currentStepTime -= Time.deltaTime;
        if (currentStepTime <= 0f)
        {
            if (soundEffectPlayer != null)
            {
                soundEffectPlayer.PlaySound(SoundType.STEP);
            }
            currentStepTime = stepInterval;
        }
    }

    private void UpdateLighterRotation(bool facingLeft)
    {
        if (lighter != null)
        {
            lighter.transform.localEulerAngles = facingLeft ? leftRotation : rightRotation;
        }
    }

    public void ActivateLighter()
    {
        this.lighter.gameObject.SetActive(true);
    }
}
