using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _audioManager;
    public static AudioManager AudioManagerInstance
    {
        get
        {
            if (_audioManager == null)
            {
                Debug.Log("Audio Manager is null!");
            }
            return _audioManager;
        }
    }

    public AudioSource voiceOver;
    private void Awake()
    {
        _audioManager = this;
    }
    public void PlayVoiceOver(AudioClip clipToPlay)
    {
        voiceOver.clip = clipToPlay;
        voiceOver.Play();
    }
}
