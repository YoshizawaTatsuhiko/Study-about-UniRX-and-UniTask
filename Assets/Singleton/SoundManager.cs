using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 日本語対応
public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance = null;
    public static SoundManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<SoundManager>();

                if (_instance == null)
                {
                    Debug.LogError($"{_instance} is Nothing");
                }
            }
            return _instance;
        }
    }

    private AudioSource _bgmAudio = null;
    private AudioSource _seAudio = null;

    private void Awake()
    {
        _bgmAudio = gameObject.AddComponent<AudioSource>();
        _seAudio = gameObject.AddComponent<AudioSource>();
    }

    public float BgmVolume { get => _bgmAudio.volume; set => _bgmAudio.volume = Mathf.Clamp01(value); }
    public float SeVolume { get => _seAudio.volume; set => _seAudio.volume = Mathf.Clamp01(value); }

    public void PlayBgm(AudioClip audioClip)
    {
        _bgmAudio.clip = audioClip;

        if (_bgmAudio) _bgmAudio.Play();
    }

    public void PlaySe(AudioClip audioClip)
    {
        _seAudio.clip = audioClip;

        if (_seAudio) _seAudio.PlayOneShot(audioClip);
    }
}
