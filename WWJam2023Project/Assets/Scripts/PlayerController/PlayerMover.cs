using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed = 5f; // The movement speed of the player

    [SerializeField] private Rigidbody2D _rb; // Reference to the Rigidbody2D component

    public Vector2 MoveInput { get; set; }

    public Vector3Variable _playerPosition;

    private void Update()
    {
        _playerPosition.Value = transform.position;
    }

    private void FixedUpdate()
    {
        // Read the input axes
        float horizontal = MoveInput.x;
        float vertical = MoveInput.y;

        // Calculate the movement vector
        Vector2 movement = new Vector2(horizontal, vertical);

        // Normalize the movement vector and apply the speed
        movement = movement.normalized * _speed;

        // Apply the movement to the Rigidbody2D
        _rb.velocity = movement;
    }
}
