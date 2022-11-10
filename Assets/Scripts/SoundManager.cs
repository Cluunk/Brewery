using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource backgroundMusic;
    [SerializeField] private GameObject audioObject;
    private readonly List<AudioSource> activeAudio = new List<AudioSource>();
    [SerializeField, Range(0, 1)] private float volume;

    public float Volume
    {
        get => volume;
        set
        {
            volume = value;
            foreach (var audioSource in activeAudio)
                audioSource.volume = volume;
        }
    }

    public static SoundManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
        
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        backgroundMusic.volume = volume;
        activeAudio.Add(backgroundMusic);
    }

    private void Update()
    {
        var clipsToRemove = new List<AudioSource>();
        foreach (var audioSource in activeAudio)
        {
            if(audioSource.time >= audioSource.clip.length)
                clipsToRemove.Add(audioSource);
        }

        foreach (var audioSource in clipsToRemove)
            RemoveAudio(audioSource);
    }

    public void PlayAudio(AudioClip clip)
    {
        if (!clip)
            return;
        
        var audioObj = Instantiate(audioObject, transform).GetComponent<AudioSource>();
        audioObj.clip = clip;
        audioObj.volume = volume;
        audioObj.Play();
        activeAudio.Add(audioObj);
    }

    private void RemoveAudio(AudioSource source)
    {
        activeAudio.Remove(source);
        Destroy(source.gameObject);
    }
}
