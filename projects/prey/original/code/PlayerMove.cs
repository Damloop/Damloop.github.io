using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("Movement Settings")]
    public float runSpeed = 7f;
    public float rotationSpeed = 250f;

    [Header("Jump Settings")]
    public float jumpHeight = 3f;
    public Transform groundCheck;
    public float groundDistance = 0.1f;
    public LayerMask groundMask;

    [Header("Components")]
    public Animator animator;
    public Rigidbody rb;

    private float x, y;
    private bool isGrounded;

    void Update()
    {
        HandleInput();
        HandleMovement();
        HandleAnimations();
        HandleJump();
    }

    // Reads player input
    void HandleInput()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
    }

    // Player rotation and movement
    void HandleMovement()
    {
        transform.Rotate(0, x * rotationSpeed * Time.deltaTime, 0);
        transform.Translate(0, 0, y * runSpeed * Time.deltaTime);
    }

    // Animation control
    void HandleAnimations()
    {
        animator.SetFloat("VelX", x);
        animator.SetFloat("VelY", y);

        bool isMoving = x != 0 || y != 0;
        animator.SetBool("Other", isMoving);

        if (Input.GetKey("p"))
            animator.Play("PUNCH");

        if (Input.GetKey("l"))
            animator.Play("JUMP");
    }

    // Jump logic
    void HandleJump()
    {
        // Ground detection using a small sphere
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // Delayed jump animation and force
        if (Input.GetKey("l") && isGrounded)
            Invoke(nameof(Jump), 1f);
    }

    // Applies upward force to perform the jump
    void Jump()
    {
        rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
    }
}
