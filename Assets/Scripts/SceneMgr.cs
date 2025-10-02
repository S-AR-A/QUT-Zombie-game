using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

    
public class SceneMgr : MonoBehaviour
{
    public Text score;
    public AudioSource audioSource;
    public AudioClip death1;
    public AudioClip death2;
    public AudioClip death3;
    public AudioClip death4;
    public AudioClip death5;
    public AudioClip death6;
    public AudioClip death7;
    public AudioClip death8;
    public AudioClip death9;
    public AudioClip death10;
    public AudioClip death11;

    // Start is called before the first frame update
    void Start()
    {
        score.text = Zombie.ZsDead.ToString();
        switch(Random.Range(1,12))
            {
            case 1:PlaySound(death1);break;
            case 2:PlaySound(death2); break;
            case 3: PlaySound(death3); break;
            case 4: PlaySound(death4); break;
            case 5: PlaySound(death5); break;
            case 6: PlaySound(death6); break;
            case 7: PlaySound(death7); break;
            case 8: PlaySound(death8); break;
            case 9: PlaySound(death9); break;
            case 10: PlaySound(death10); break;
            case 11: PlaySound(death11); break;

            default: break;
        }

    }
    void PlaySound(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Main Menu");

        }
    }
}
