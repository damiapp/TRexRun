using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip jumpSound;
    public AudioClip deathSound;
    public AudioClip checkPointSound;
    public AudioClip fartSound;
    public AudioSource audioSource;
    

    public void PlayJumpSound()
    {
        audioSource.PlayOneShot(jumpSound);
    }
    public void PlayDeathSound()
    {
        audioSource.PlayOneShot(deathSound);
    }
    public void PlayCheckPointSound()
    {
        audioSource.PlayOneShot(checkPointSound);
    }
    public void PlayFartSound(){
        audioSource.PlayOneShot(fartSound);
    }
}
