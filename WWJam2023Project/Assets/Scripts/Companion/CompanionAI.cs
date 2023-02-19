using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionAI : MonoBehaviour
{
    public float speed = 10.0f;

    public float followPlayerSpeed = 4.0f;

    [SerializeField] private Rigidbody2D _rb;

    [SerializeField] private Vector3Variable _playerPosition;

    public float stopDistance = 2.0f;

    public Vector2 MoveInput { get; set; }

    public bool IsFollowingPlayer;
    public bool IsGoingToEdge;

    private float _currentSpeed;

    private void Start()
    {
        MoveInput = Vector2.down;
        SendInDirection(new Vector2(-1, -1));
    }

    private void Update()
    {
        if (IsFollowingPlayer)
        {
            float distanceFromPlayer = Mathf.Abs((transform.position - _playerPosition.Value).magnitude);
            if (distanceFromPlayer <= stopDistance)
            {
                _currentSpeed = followPlayerSpeed;
                MoveInput = Vector2.zero;
            }
            else
            {
                MoveInput = (_playerPosition.Value - transform.position).normalized * speed;
            }
        }
    }

    private void FixedUpdate()
    {
        // Read the input axes
        float horizontal = MoveInput.x;
        float vertical = MoveInput.y;

        // Calculate the movement vector
        Vector2 movement = new Vector2(horizontal, vertical);

        // Normalize the movement vector and apply the speed
        movement = movement.normalized * _currentSpeed;

        // Apply the movement to the Rigidbody2D
        _rb.velocity = movement;
    }

    public void SendInDirection(Vector2 direction)
    {
        _currentSpeed = speed;
        IsFollowingPlayer = false;
        IsGoingToEdge = true;
        MoveInput = direction.normalized * _currentSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.collider.CompareTag("LevelBound"))
        {
            IsGoingToEdge = false;
            IsFollowingPlayer = true;
            _currentSpeed = speed;
        }
    }
}
