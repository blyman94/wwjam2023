using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Vector3Variable TreePosition;
    public bool PlayerIsNearEnemy { get; set; } = false;

    public float stopDistance = 2.0f;

    public Vector2 MoveInput { get; set; }

    [SerializeField] private Rigidbody2D _rb;

    public float speed = 10.0f;

    private void Start()
    {
        MoveInput = (TreePosition.Value - transform.position).normalized * speed;
    }

    private void FixedUpdate()
    {
        // Read the input axes
        float horizontal = MoveInput.x;
        float vertical = MoveInput.y;

        // Calculate the movement vector
        Vector2 movement = new Vector2(horizontal, vertical);

        // Normalize the movement vector and apply the speed
        movement = movement.normalized * speed;

        // Apply the movement to the Rigidbody2D
        _rb.velocity = movement;
    }


    public void OnPlayerInteractResponse()
    {
        if (!PlayerIsNearEnemy)
        {
            return;
        }

        Destroy(gameObject);
    }
}
