using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Game _game;
    [SerializeField] private int _playerSpeed;
    [SerializeField] private int _jumpSpeed;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _groundCheckDistance;


    private Rigidbody _rigidbody;
    private float _radius;
    private string _horizontalAxisName = "Horizontal";
    private string _verticalAxisName = "Vertical";
    private bool _isJumping = false;
    private bool IsGrounded => Physics.Raycast(transform.position, Vector3.down, _radius + _groundCheckDistance, _groundLayer);

    private void Start()
    {
        _rigidbody = GetComponentInChildren<Rigidbody>();
        _radius = GetComponent<SphereCollider>().radius;
    }

    private void Update()
    {
        if (_game.IsFinished)
            return;

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
            _isJumping = true;
    }

    private void FixedUpdate()
    {
        if (_game.IsFinished)
            return;

        HandleMovement();

        if (_isJumping)
            Jump();
    }

    private Vector3 CalculateDirection()
    {
        float xInput = Input.GetAxisRaw(_horizontalAxisName);
        float zInput = Input.GetAxisRaw(_verticalAxisName);

        return new Vector3(xInput, 0, zInput).normalized;
    }

    private void HandleMovement()
    {
        Vector3 direction = CalculateDirection();

        _rigidbody.AddForce(direction * _playerSpeed, ForceMode.Force);
    }

    private void Jump()
    {
        _rigidbody.AddForce(Vector3.up * _jumpSpeed, ForceMode.Impulse);

        _isJumping = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector3 targetDrawPosition = transform.position - new Vector3(0, _radius + _groundCheckDistance, 0);
        Gizmos.DrawLine(transform.position, targetDrawPosition);
    }
}
