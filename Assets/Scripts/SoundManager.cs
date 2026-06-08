using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public float volume = 0.5f;
    public AudioSource musicSource;
    public AudioClip musicClip;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        musicSource = GetComponent<AudioSource>();
        musicSource.volume = volume;
        musicSource.clip = musicClip;
        musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
