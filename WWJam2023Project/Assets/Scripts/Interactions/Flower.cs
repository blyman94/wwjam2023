using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    public GameObject minimapGO;
    public AudioSource flowerAudio;
    public AudioClip pickupAudioClip;
    public SpriteRenderer flowerRenderer;
    public bool PlayerIsNearFlower { get; set; } = false;
    public BoolVariable _playerHasFlower;
    public GameObject promptGO;
    public BoxCollider2D trigger;

    public void OnPlayerInteractResponse()
    {
        if (!PlayerIsNearFlower)
        {
            return;
        }

        trigger.enabled = false;
        flowerAudio.PlayOneShot(pickupAudioClip);
        _playerHasFlower.Value = true;
        promptGO.SetActive(false);
        minimapGO.SetActive(false);
        flowerRenderer.color = Color.clear;
    }
}
