using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour

{
    public AudioClip jumpSFX;
    public AudioClip coinSFX;
    public AudioClip flashSFX;
    public AudioClip deathSFX;

    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayDeath()
    {
        audio.PlayOneShot(deathSFX);
    }

    public void PlayCoin()
    {
        audio.PlayOneShot(coinSFX);
    }
    public void PlayToggleFlash()
    {
        audio.PlayOneShot(flashSFX);
    }

    public void PlayJump()
    {
        audio.PlayOneShot(jumpSFX);
    }
}
