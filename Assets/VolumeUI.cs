using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeUI : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void ChangeBGMVolume(float volume) => audioMixer.SetFloat("BGM", volume);
    public void ChangeSFXVolume(float volume) => audioMixer.SetFloat("SFX", volume);
}
