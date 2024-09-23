using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioActivator : MonoBehaviour
{
    [SerializeField] private AudioSource music;
    [SerializeField] private GameObject UIPanel;

    private void Update()
    {
        if (UIPanel.gameObject.activeSelf)
        {
            if (music.isPlaying)
            {
                music.Stop();
            }
        }
        else
        {
            if (!music.isPlaying)
            {
                music.Play();
            }
        }
    }
}
