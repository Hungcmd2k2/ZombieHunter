using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject UI;
    public GameObject Crosshair;
    public GameObject Gun;
    public Wepon musicWepon;
    public GameObject MusicMemeOn;
    public GameObject MusicMemeOff;
    public GameObject UI_DIE;
    public Toggle music;
    public AudioSource musicSource;
    public AudioClip[] musicClip;
    void Start()
    {
        music.onValueChanged.AddListener(delegate
        {
            ToggleValueChanged(music);
        });
        PlayMusic();
    }
    void ToggleValueChanged(Toggle change)
    {
        if (change.isOn == true)
        {
            Debug.Log("Bat tieng");
            PlayMusic();
        }
        else
        {
            Debug.Log("Tat tieng");
            musicSource.Stop();
        }
    }
    public void PlayMusic()
    {
        if (musicSource.isPlaying == false)
        {
            int randomIndex = Random.Range(0, musicClip.Length);
            musicSource.clip = musicClip[randomIndex];
            musicSource.Play();
        }
        Invoke("PlayMusic", musicSource.clip.length);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
            UI.SetActive(true);
            Crosshair.SetActive(false);
            Gun.SetActive(false);
            Cursor.visible = true;
        }
    }
    public void OnMusicMeme()
    {
        musicWepon.MusicMeme = true;
        MusicMemeOn.SetActive(true);
        MusicMemeOff.SetActive(false);
    }
    public void OffMusicMeme()
    {
        musicWepon.MusicMeme = false;
        MusicMemeOff.SetActive(true);
        MusicMemeOn.SetActive(false);
    }


    public void Continue()
    {
        Time.timeScale = 1;
        UI.SetActive(false);
        UI.SetActive(false);
        Crosshair.SetActive(true);
        Gun.SetActive(true);
        Cursor.visible = false;
    }
    public void PauseGame()
    {
        Time.timeScale = 0;

    }
    public void ExitToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
