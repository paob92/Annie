using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundOptions : MonoBehaviour
{
    public Slider sound;
    public Slider sfx;

    void Start()
    {
        sound.onValueChanged.AddListener(delegate
        {
            AudioManager.instance.ChangeMusicVolume(sound.value);
        } );

        sfx.onValueChanged.AddListener(delegate
        {
            AudioManager.instance.ChangeSFXVolume(sfx.value);
        });

        sound.value = AudioManager.instance.GetMusicVolume();
        sfx.value = AudioManager.instance.GetSFXVolume();
    }


   
}
