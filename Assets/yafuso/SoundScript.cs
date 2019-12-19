using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{

    public AudioClip TitleSE;
    AudioSource audioSource;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();   
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            audioSource.PlayOneShot(TitleSE);
        }
        
    }
}
