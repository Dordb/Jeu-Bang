using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>Main_Menu_AudioScript</c> gère le son du jeu
/// </summary>
public class Main_Menu_AudioScript : MonoBehaviour
{

    public AudioClip audioClip;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioClip = Resources.Load<AudioClip>("Audio/Digital_Gunslinger2");
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
