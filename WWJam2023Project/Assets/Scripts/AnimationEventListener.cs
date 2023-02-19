using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventListener : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip footstepClip;
    public void PlayFootstep()
    {
        audioSource.PlayOneShot(footstepClip);
    }
}
