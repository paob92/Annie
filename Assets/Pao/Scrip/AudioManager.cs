using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioMixer mixer;
    public float sfxVolume = 0;
    public float musicVolume = 0;

    public GameObject ambientSoundUI;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }


    }
    private void Start()
    {
        if (PlayerPrefs.HasKey("SFXVolume"))
        {
            sfxVolume = PlayerPrefs.GetFloat("SFXVolume");
            Debug.Log("mocoso " + PlayerPrefs.GetFloat("SFXVolume"));
            ChangeSFXVolume(sfxVolume);
        }

        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            ChangeMusicVolume(PlayerPrefs.GetFloat("MusicVolume"));
        }
    }



    public void ChangeSFXVolume(float newVolume)
    {
        sfxVolume = newVolume;
        mixer.SetFloat("SFXVolume", newVolume);
        PlayerPrefs.SetFloat("SFXVolume", newVolume);
    }

    public void ChangeMusicVolume(float newVolume)
    {
        musicVolume = newVolume;
        mixer.SetFloat("MusicVolume", newVolume);
        PlayerPrefs.SetFloat("MusicVolume", newVolume);
    }

    public float GetMusicVolume()
    {
        return musicVolume;
    }

    public float GetSFXVolume()
    {
        return sfxVolume;
    }

    public void SwitchStateAmbienSoundUI(bool newState)
    {
        if (ambientSoundUI != null)
        {
            ambientSoundUI.SetActive(newState);
        }
    }
}
