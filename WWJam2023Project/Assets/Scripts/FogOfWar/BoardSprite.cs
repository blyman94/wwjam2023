using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardSprite : MonoBehaviour
{
    public SpriteRenderer PureSpriteRenderer;
    public SpriteRenderer CorruptSpriteRenderer;

    public void SwitchToPure()
    {
        PureSpriteRenderer.gameObject.SetActive(true);
        CorruptSpriteRenderer.gameObject.SetActive(false);
    }
    public void SwitchToCorrupt()
    {
        PureSpriteRenderer.gameObject.SetActive(false);
        CorruptSpriteRenderer.gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SwitchToPure();
        }
    }
}
