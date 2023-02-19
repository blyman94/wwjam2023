using UnityEngine;

public class AlphaPingPong : MonoBehaviour
{
    public float minAlpha = 0.2f;
    public float maxAlpha = 1.0f;
    public float pingPongSpeed = 1.0f;

    [SerializeField] private SpriteRenderer spriteRenderer;
    private Color spriteColor;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteColor = spriteRenderer.color;
    }

    void OnEnable()
    {

    }

    void Update()
    {
        float alpha = Mathf.PingPong(Time.time * pingPongSpeed, maxAlpha - minAlpha) + minAlpha;
        spriteColor.a = alpha;
        spriteRenderer.color = spriteColor;
    }
}