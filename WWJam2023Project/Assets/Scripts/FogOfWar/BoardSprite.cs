using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardSprite : MonoBehaviour
{
    public SpriteRenderer PureSpriteRenderer;
    public SpriteRenderer CorruptSpriteRenderer;
    public BoxCollider2D bc2d;

    public void SwitchToPure()
    {
        bc2d.enabled = false;
        PureSpriteRenderer.gameObject.SetActive(true);
        CorruptSpriteRenderer.gameObject.SetActive(false);
    }
    public void SwitchToCorrupt()
    {
        bc2d.enabled = true;
        PureSpriteRenderer.gameObject.SetActive(false);
        CorruptSpriteRenderer.gameObject.SetActive(true);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Bunny"))
        {
            SwitchToPure();
        }
    }
}
