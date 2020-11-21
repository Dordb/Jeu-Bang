using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{

    public static SoundManagerScript instance = null;


    public static AudioClip bangSound, biereSound, nopeSound, gatlingSound, oofSound, indianSound;
    public static AudioClip music1, music2, music3, music4;
    private static AudioSource[] audioSrc;

    private AudioClip[] list;

    private int i;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

    }

    // Start is called before the first frame update
    void Start()
    {
        bangSound = Resources.Load<AudioClip>("Sound/Bang");
        biereSound = Resources.Load<AudioClip>("Sound/Biere");
        nopeSound = Resources.Load<AudioClip>("Sound/Nope");
        gatlingSound = Resources.Load<AudioClip>("Sound/Gatling");
        oofSound = Resources.Load<AudioClip>("Sound/Oof");
        indianSound = Resources.Load<AudioClip>("Sound/Indian");
        audioSrc = GetComponents<AudioSource>();

        music1 = Resources.Load<AudioClip>("Sound/Digital_Gunslinger2");
        music2 = Resources.Load<AudioClip>("Sound/Outlaws_Scantuary");
        music3 = Resources.Load<AudioClip>("Sound/Outlaws_Scantuary2");
        music4 = Resources.Load<AudioClip>("Sound/Starcraft_2_Public_Enemy");

        list = new AudioClip[4];
        list[0] = music1;
        list[1] = music2;
        list[2] = music3;
        list[3] = music4;
        i = 0;


    }


    public static void PlaySound(string soundName)
    {
        switch (soundName)
        {
            case "Bang":
                audioSrc[0].PlayOneShot(bangSound);
                break;
            case "Biere":
                audioSrc[0].PlayOneShot(biereSound);
                break;
            case "Nope":
                audioSrc[0].PlayOneShot(nopeSound);
                break;
            case "Gatling":
                audioSrc[0].PlayOneShot(gatlingSound);
                break;
            case "Oof":
                audioSrc[0].PlayOneShot(oofSound);
                break;
            case "Indian":
                audioSrc[0].PlayOneShot(indianSound);
                break;
        }
    }

    private void Update()
    {
        if(audioSrc[1].isPlaying == false)
        {
            audioSrc[1].clip = list[i];
            audioSrc[1].Play();
            i = (i + 1) % list.Length;
        }
    }


    public void changeSound()
    {
        audioSrc[1].Play(0);
    }

    public void setVolumeMusic(float vol)
    {
        audioSrc[1].volume = vol;
    }
    public void setVolumeEffects(float vol)
    {
        audioSrc[0].volume = vol;
    }

}
