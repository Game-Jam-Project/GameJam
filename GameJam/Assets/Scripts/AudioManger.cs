using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManger : MonoBehaviour
{
    public static AudioManger instance;

    [SerializeField] private AudioMixerGroup masterMixer;

    [Header("Sounds Array")]
    [SerializeField] private Sound[] sounds;

    private void Awake()
    {
        DontDestroyOnLoad(this);

        if (instance == null)
            instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();

            s.source.clip = s.clip;
            s.source.outputAudioMixerGroup = masterMixer;

            s.source.volume = s.volume * ( 1 + UnityEngine.Random.Range(-s.randomVolume / 2f, s.randomVolume / 2f) );
            s.source.pitch = s.pitch * ( 1 + UnityEngine.Random.Range(-s.randomPitch / 2f, s.randomPitch / 2f) );

            s.source.loop = s.loop;
        }
    }

    public void Play(string soundName)
    {
        Sound s = Array.Find(sounds, sound => sound.name == soundName);
        if (s == null)
        {
            Debug.LogError($"Thire was an error in getting the sound, Check the sound name if its correct ({ soundName }).");
            return;
        }

        s.source.Play();
    }

    public void Stop(string soundName)
    {
        Sound s = Array.Find(sounds, sound => sound.name == soundName);
        if (s == null)
        {
            Debug.LogError($"Thire was an error in getting the sound, Check the sound name if its correct ({ soundName }).");
            return;
        }

        s.source.Stop();
    }
}