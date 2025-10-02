using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GunManager : MonoBehaviour
{
    public Transform cameraPos;
    public GameObject bullet;
    private RaycastHit hit;
    public Animation gunAnim;
    public float BulletAmount;
    public bool canShoot;
    public GameObject nobullets;
    public float BulletNeed;
    public float DestoryTime;
    public bool IsGameOver;
    public AudioSource audioSource;
    public AudioClip ShootSfx, ReloadSfx;
    public string GunName;
    public Sprite GunImage;
    public PlayerManager playerManager;
    public GameObject GameOverPanel;

    private void Start()
    {
        IsGameOver = false;
        DestoryTime = 0.5f;
        BulletAmount = 30;

    }

    private float timer = .1f;
    private float reload_timer = 0f;
    private bool isreloading = false;

    void Update()
    {
        if (reload_timer < 0) isreloading = false;
        reload_timer -= Time.deltaTime;
        gunAnim["Fire"].speed = 5f;
        CheckHealth();
        CheckBulletAmount();
        LayerMask hitMask = ~LayerMask.GetMask("player collider","player");
        //getmousebuttondown(0)
        if (Input.GetMouseButton(0)&& ((timer-=Time.deltaTime) < 0)&& !isreloading)
        {
            if (canShoot && Physics.Raycast(cameraPos.position, cameraPos.forward, out hit, 30,hitMask) && !IsGameOver)
            {

                GameObject BulletClone = Instantiate(bullet, hit.point, Quaternion.identity);
                BulletAmount--;
                PlaySound(ShootSfx);
                gunAnim.Play("Fire");

                Destroy(BulletClone, DestoryTime);
                if ((timer -= Time.deltaTime) < 0) timer = .1f;
                

            }
        }
        if (Input.GetKeyDown(KeyCode.R) && ((reload_timer < 0)))
        {
            gunAnim.Stop();
            isreloading = true;
            PlaySound(ReloadSfx);
            //StartCoroutine(reloadtime(2f));
            gunAnim.Play("Reload");
            BulletAmount = 30;
            if ((reload_timer -= Time.deltaTime) < 0) reload_timer = 3f;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //PlayerPrefs.SetInt("MyInt", Zombie.ZsDead);
            //PlayerPrefs.Save();
            SceneManager.LoadScene("Main Menu");
            
        }
    }

    //private IEnumerator reloadtime(float delay)
    //{
       
    //    gunAnim.Play("Reload");
    //    BulletAmount = 30;
    //    yield return new WaitForSeconds(delay);
    //}


    void CheckBulletAmount()
    {
        if (BulletAmount > 0)
        {
            canShoot = true;
            nobullets.SetActive(false);

        }
        else
        {
            canShoot = false;
            nobullets.SetActive(true);
        }
    }
    void PlaySound(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
    void CheckHealth()
    {
        if (playerManager.PlayerHealth>0)
        {
            IsGameOver = false;
        } 
        else if (playerManager.PlayerHealth <= 0)
        {
            //IsGameOver = true;
            //playerManager.PlayerHealth = 0;
            //GameOverPanel.SetActive(true);
            SceneManager.LoadScene("Death Scene");

        }
    }

}
