using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 日本語対応
public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance = null;
    public static SoundManager Instance => _instance;

    [SerializeField]
    private AudioSource _bgmAudio = null;
    [SerializeField]
    private AudioSource _seAudio = null;

    private void Awake()
    {
        if (!_instance)
        {
            _instance = this;
            DontDestroyOnLoad(_instance);
        }
        else
        {
            Destroy(this);
        }

        if (!_bgmAudio) _bgmAudio = gameObject.AddComponent<AudioSource>();
        if (!_seAudio) _seAudio = gameObject.AddComponent<AudioSource>();
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
