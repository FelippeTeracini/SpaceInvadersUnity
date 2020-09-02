using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject mainCanvas;
    public GameObject settingsCanvas;
    public Slider masterVolumeSlider;

    private void Start() {
        masterVolumeSlider.value = PlayerPrefs.GetFloat("MasterVolume", 1);
        AudioListener.volume = PlayerPrefs.GetFloat("MasterVolume", 1);
        Time.timeScale = 1;
    }

    public void StartGame() {
        SceneManager.LoadScene("LVL00");
    }

    public void ShowSettings() {
        mainCanvas.SetActive(false);
        settingsCanvas.SetActive(true);
    }

    public void HideSettings() {
        mainCanvas.SetActive(true);
        settingsCanvas.SetActive(false);
    }

    public void UpdateMasterVolume() {
        PlayerPrefs.SetFloat("MasterVolume", masterVolumeSlider.value);
        AudioListener.volume = masterVolumeSlider.value;
        PlayerPrefs.Save();
    }
}
