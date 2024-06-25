using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_1 : MonoBehaviour
{
    public GameObject UI_INFOR;
    public AudioSource musicSource;
    public AudioClip[] musicClip;
    public GameObject textcredit;
    public GameObject canvan;
    void Start()
    {
        musicSource.PlayOneShot(musicClip[Random.Range(0, musicClip.Length)]);
        Time.timeScale = 1;
    }

    void Update()
    {
        if (musicSource.isPlaying == false)
        {
            musicSource.PlayOneShot(musicClip[Random.Range(0, musicClip.Length)]);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UI_INFOR.SetActive(false);
            textcredit.SetActive(false);
            canvan.SetActive(true);
        }
    }
    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void Information()
    {
        UI_INFOR.SetActive(true);
        canvan.SetActive(false);
    }
    public void Credit()
    {
        textcredit.SetActive(true);
        canvan.SetActive(false);
    }
}
