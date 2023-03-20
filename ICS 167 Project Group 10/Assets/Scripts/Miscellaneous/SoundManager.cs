using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    // singleton so i can reference for other music
    [SerializeField]
    private AudioSource m_SFXAudioSource;

    [SerializeField]
    private AudioSource m_MusicAudioSource;

    private static SoundManager _instance;


    // Start is called before the first frame update
    void Start()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(_instance);
        }
        else
        {
            Destroy(this);
        }
    }

    // Update is called once per frame
    public static void PlaySFX(AudioClip clip)
    {
        _instance.m_SFXAudioSource.PlayOneShot(clip);
    }

    public static void PlayMusic(AudioClip clip)
    {
        _instance.m_MusicAudioSource.Stop();
        _instance.m_MusicAudioSource.clip = clip;
        _instance.m_MusicAudioSource.Play();
    }
}
