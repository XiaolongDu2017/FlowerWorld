using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;

    public static AudioManager instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject tGo = new GameObject("AudioManager");
                _instance = tGo.AddComponent<AudioManager>();
                DontDestroyOnLoad(tGo);
            }

            return _instance;
        }
    }

    private AudioClip[] clipsBackground;
    private AudioClip[] clipsOthers;
    private Dictionary<string, AudioClip> clipsDictionary;
    private List<AudioSource> audioSourceList;
    private List<AudioSource> audioSourceSpare;

    private void Awake()
    {
        clipsBackground = Resources.LoadAll<AudioClip>("AudioClips/背景音乐");
        clipsOthers = Resources.LoadAll<AudioClip>("AudioClips/音效");
        clipsDictionary = new Dictionary<string, AudioClip>();
//        clipGive = new AudioClip();
        eptLoopSource = gameObject.AddComponent<AudioSource>();
        audioSourceList = new List<AudioSource>();
        audioSourceSpare = new List<AudioSource>();
        AddAudioClipsToAAudioDic();
    }

    private AudioSource playSource;
    private AudioSource eptLoopSource;

    public void PlayLoopAudio(string myAudioName)
    {
        playSource = eptLoopSource;
        playSource.clip = SelectAudioByName(myAudioName);
        if (!playSource.loop)
        {
            playSource.playOnAwake = true;
            playSource.loop = true;
        }

        playSource.Play();
    }

    public void PlayAudio(string myAudioName)
    {
        if (string.IsNullOrEmpty(myAudioName))
            return;
        CleanSpareAudioSource();
        AudioSource eptSource = gameObject.AddComponent<AudioSource>();
        playSource = eptSource;
        audioSourceList.Add(eptSource);
        playSource.clip = SelectAudioByName(myAudioName);
        if (myAudioName == "button")
        {
            playSource.volume = 0.5f;
        }

        if (playSource.loop)
        {
            playSource.playOnAwake = false;
            playSource.loop = false;
        }

        playSource.Play();
    }

    void AddAudioClipsToAAudioDic()
    {
        foreach (var item in clipsBackground)
        {
            clipsDictionary.Add(item.name, item);
        }

        foreach (var item in clipsOthers)
        {
            clipsDictionary.Add(item.name, item);
        }
    }

    AudioClip clipGive = null;

    AudioClip SelectAudioByName(string clipName)
    {
        for (int i = 0; i < clipsDictionary.Count; i++)
        {
            if (clipsDictionary[clipName] != null)
            {
                clipGive = clipsDictionary[clipName];
            }
        }

        return clipGive;
    }

    AudioSource sourceGive = null;
    private int eptI;
    private int audioCount;

    void CleanSpareAudioSource()
    {
        foreach (var item in audioSourceList)
        {
            if (!item.isPlaying)
            {
                DestroyObject(item);
                audioSourceSpare.Add(item);
            }
        }

        foreach (var item in audioSourceSpare)
        {
            audioSourceList.Remove(item);
        }
    }
}