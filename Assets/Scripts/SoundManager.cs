using UnityEngine;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour {

    public List<AudioClip> Clips = new List<AudioClip>();

    public static SoundManager Instance
    {
        get
        {
            if (instance == null)
                instance = GameObject.FindObjectOfType(typeof(SoundManager)) as SoundManager;
            return instance;
        }

    }
    private static SoundManager instance;

    void Awake()
    {
        audio.Play();
    }

    public void PlaySound(AudioClip clip)
    {
        Debug.Log("playing sound" + clip.name);
        audio.PlayOneShot(clip);
    }
}

