using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public int levelCount = 1;
    public int score = 0;
    public int highscore = 0;
    bool paused = false;
    bool gameEnded = false;
    bool bossSpawned = false;

    public Aliens aliens;
    public GameObject boss;
    GameObject inGameBoss;
    public LevelCount levelcount;
    public GameObject player;
    public Victory victory;
    public GameObject endgameButtons;

    public GameObject settingCanvas;
    public Slider masterVolumeSlider;

    AudioManager audioManager;

    public int maxLevels = 6;

    private void Start()
    {
        Time.timeScale = 1f;
        highscore = PlayerPrefs.GetInt("HighScore", highscore);

        masterVolumeSlider.value = PlayerPrefs.GetFloat("MasterVolume", 1);
        AudioListener.volume = PlayerPrefs.GetFloat("MasterVolume", 1);

        audioManager = GetComponent<AudioManager>();

        audioManager.Play("Music");
    }

    void Update()
    {
        if (aliens.transform.childCount == 0 && levelCount < maxLevels - 1)
        {
            levelCount += 1;
            aliens.spawnAliens();
            levelcount.UpdateText();
        }

        if (aliens.transform.childCount == 0 && levelCount == 5 && !bossSpawned) {
            inGameBoss = Instantiate(boss, new Vector3(0f, 2.5f, 0f), Quaternion.identity);
            bossSpawned = true;
            levelCount += 1;
            levelcount.UpdateText();
        }

        // if (Input.GetKeyDown(KeyCode.R))
        // {
        //     Restart();
        // }
        if (Input.GetKeyDown(KeyCode.Escape) && !gameEnded)
        {
            if (paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        if (score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("HighScore", highscore);
            PlayerPrefs.Save();
        }

        if (player == null)
        {
            Lose();
        }
        else if (inGameBoss == null && levelCount == maxLevels)
        {
            Win();
        }

    }

    public void UpdateMasterVolume()
    {
        PlayerPrefs.SetFloat("MasterVolume", masterVolumeSlider.value);
        AudioListener.volume = masterVolumeSlider.value;
        PlayerPrefs.Save();
    }

    public void Lose()
    {
        gameEnded = true;
        Time.timeScale = 0;
        victory.UpdateText("You Lose!");
        endgameButtons.SetActive(true);
        player.GetComponent<Player>().paused = true;
    }

    public void Win()
    {
        gameEnded = true;
        Time.timeScale = 0;
        victory.UpdateText("You Win!");
        endgameButtons.SetActive(true);
        player.GetComponent<Player>().paused = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene("LVL00");
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Mainmenu");
    }

    void Pause()
    {
        paused = true;
        Time.timeScale = 0f;
        settingCanvas.SetActive(true);
        player.GetComponent<Player>().paused = true;
    }

    public void Resume()
    {
        paused = false;
        Time.timeScale = 1f;
        settingCanvas.SetActive(false);
        player.GetComponent<Player>().paused = false;
    }
}
