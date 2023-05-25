using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public Slider volumeSlider;
    public bool quarter = false;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("volume"))
            PlayerPrefs.SetFloat("volume", .7f);

        Load();
    }

    public void ChangeVolume()
    {
        if (quarter)
            AudioListener.volume = volumeSlider.value * 4;
        else
            AudioListener.volume = volumeSlider.value;
        Save();
    }

    private void Save()
    {
        if (quarter)
            PlayerPrefs.SetFloat("volume", volumeSlider.value * 4);
        else
            PlayerPrefs.SetFloat("volume", volumeSlider.value);
    }

    private void Load()
    {
        if (!PlayerPrefs.HasKey("volume")) return;

        if (quarter)
            volumeSlider.value = PlayerPrefs.GetFloat("volume") / 4;
        else
            volumeSlider.value = PlayerPrefs.GetFloat("volume");
        ChangeVolume();
    }
}
