using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicLoader : MonoBehaviour
{
    [SerializeField] private AudioClip musicClip;

    void Start()
    {
        AudioManager.Instance.PlayMusic(musicClip);
    }
}
