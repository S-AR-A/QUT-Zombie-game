using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip ButtonClickSound;
    public void Update()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

    }
    public void StartGame()
    {
        PlaySound(ButtonClickSound);
        Zombie.ZsDead = 0;
        SceneManager.LoadScene("City");
    }
    public void Morning()
    {
        PlaySound(ButtonClickSound);

        SceneManager.LoadScene("Morning");
    }
    public void QuitGame()
    {
        PlaySound(ButtonClickSound);

        Application.Quit();
        Debug.Log("Game Quit");
    }

    private void PlaySound(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
