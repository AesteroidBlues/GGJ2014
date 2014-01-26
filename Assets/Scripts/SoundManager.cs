using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

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

