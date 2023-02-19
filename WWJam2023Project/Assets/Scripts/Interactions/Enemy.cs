using System.Threading.Tasks;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer enemyRenderer;
    public GameEvent enemyHitTreeEvent;
    public Vector3Variable TreePosition;
    public bool PlayerIsNearEnemy { get; set; } = false;

    public float stopDistance = 2.0f;

    public Vector2 MoveInput { get; set; }

    [SerializeField] private Rigidbody2D _rb;

    public BoxCollider2D toggleCollider;

    public float treeDist = 10;

    public float speed = 10.0f;

    private void Start()
    {
        toggleCollider.enabled = false;
        MoveInput = (TreePosition.Value - transform.position).normalized * speed;
    }

    private void Update()
    {
        float distanceFromTree = Mathf.Abs((TreePosition.Value - transform.position).magnitude);
        if (distanceFromTree < treeDist)
        {
            toggleCollider.enabled = true;
        }

        if (MoveInput.x < 0)
        {
            enemyRenderer.flipX = false;
        }
        else
        {
            enemyRenderer.flipX = true;
        }

        animator.SetFloat("MoveX", MoveInput.x);
        animator.SetFloat("MoveY", MoveInput.y);
    }

    public void StopMovement()
    {
        MoveInput = Vector2.zero;
    }

    public void StartMovement()
    {
        MoveInput = (TreePosition.Value - transform.position).normalized * speed;
    }

    private async void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Tree"))
        {
            enemyHitTreeEvent.Raise();
            await DieAfter3Seconds();
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
        movement = movement.normalized * speed;

        // Apply the movement to the Rigidbody2D
        _rb.velocity = movement;
    }

    public void Die()
    {
        Destroy(gameObject);
    }


    public void OnPlayerInteractResponse()
    {
        if (!PlayerIsNearEnemy)
        {
            return;
        }

        Die();
    }

    public async Task DieAfter3Seconds()
    {
        await Task.Delay(3000);
        Die();
    }
}
