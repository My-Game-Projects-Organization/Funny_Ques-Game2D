using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{

    public static AudioController Ins;
    
    [Range(0f, 1f)]
    public float musicVolume;
    [Range (0f, 1f)]
    public float soundVolume;

    public AudioSource musicAus;
    public AudioSource soundAus;

    public AudioClip[] backgroundMusics;
    public AudioClip winSound;
    public AudioClip loseSound;
    public AudioClip rightSound;
    private void Awake()
    {
        MakeSingletone();
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayBackgroundMusic();
    }

    // Update is called once per frame
    void Update()
    {
        if(musicAus && soundAus)
        {
            musicAus.volume = musicVolume;
            soundAus.volume = soundVolume;
        }
    }

    public void PlayBackgroundMusic()
    {
       if(musicAus && backgroundMusics.Length > 0 && backgroundMusics != null)
        {
            int randIdx = Random.Range(0, backgroundMusics.Length);

            if(backgroundMusics[randIdx] != null)
            {
                musicAus.clip = backgroundMusics[randIdx];
                musicAus.volume = musicVolume;
                musicAus.Play();
            }
        }
    }

    public void PlaySound(AudioClip sound)
    {
        if(soundAus && sound)
        {
            soundAus.volume = soundVolume;
            soundAus.PlayOneShot(sound);
        }
    }

    public void PlayWinSound()
    {
        PlaySound(winSound);
    }
    public void PlayLoseSound()
    {
        PlaySound(loseSound);
    }
    public void PlayRightSound()
    {
        PlaySound(rightSound);
    }

    public void StopMusic()
    {
        if(musicAus != null)
        {
            musicAus.Stop();
        }
    }

    void MakeSingletone()
    {
        if (Ins == null)
        {
            Ins = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
