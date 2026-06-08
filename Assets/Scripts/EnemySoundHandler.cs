using UnityEngine;
using System.Collections.Generic;
public class EnemySoundHandler : MonoBehaviour
{
    public AudioSource audioPlayer;

    public List<AudioClip> idleSound;
    public List<AudioClip> spawnSounds;
    public List<AudioClip> deathSounds;

    public float volume = 0.01f;

    void Start()
    {
        audioPlayer.volume = volume;
        audioPlayer.clip = spawnSounds[(int)Random.Range(0, spawnSounds.Count)];
        audioPlayer.Play();
    }

    public void onDeath()
    {
        audioPlayer.clip = deathSounds[(int)Random.Range(0, deathSounds.Count)];
        audioPlayer.Play();

    }
}
