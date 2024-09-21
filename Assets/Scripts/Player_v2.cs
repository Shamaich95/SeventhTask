using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Movement parameters
    public float moveSpeed = 10f;   // Horizontal movement speed
    public float jumpForce = 5f;    // Force applied for jumping

    // Ground check parameters
    public Vector3 groundCheckOffest = new Vector3(0, 0.5f, 0);   // Position of the ground check
    public float groundCheckRadius = 0.2f; // Radius of ground check
    public LayerMask groundLayer;   // Layer to consider as ground
    private Vector3 _groundCheckPosition;

    // Rigidbody reference
    private Rigidbody rb;

    // To track if the player is grounded
    private bool isGrounded;

    void Start()
    {
        // Get the Rigidbody component attached to the object
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _groundCheckPosition = transform.position - groundCheckOffest;
        // Check if the player is on the ground
        isGrounded = Physics.CheckSphere(_groundCheckPosition, groundCheckRadius, groundLayer);

        //isGrounded = Physics.Raycast(_groundCheckPosition, Vector3.down, groundCheckRadius, groundLayer);

        if (isGrounded)
            Debug.Log("1");

        // Handle jumping
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        // Handle horizontal movement
        Move();
    }

    void Move()
    {
        // Get input for movement along X and Z axes
        float moveX = Input.GetAxis("Horizontal"); // Left/Right
        float moveZ = Input.GetAxis("Vertical");   // Forward/Backward

        // Apply movement forces
        Vector3 moveDirection = new Vector3(moveX, 0f, moveZ).normalized;

        // Apply force based on direction
        rb.AddForce(moveDirection * moveSpeed, ForceMode.Force);
    }

    void Jump()
    {
        // Apply upward force for jumping
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    void OnDrawGizmosSelected()
    {
        // Draw the ground check sphere in the editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_groundCheckPosition, groundCheckRadius);
    }
}
