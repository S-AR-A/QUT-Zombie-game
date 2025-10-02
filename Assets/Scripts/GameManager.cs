using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public GunManager _gunManager;
    public Text BulletAmountTxt;
    public Image GunImg;
    public Text GunNameTxt;
    public Text Score;
    public Text GO_Score;

    public Text BulletNeedTxt;
    public Slider HealthSlider;
    public PlayerManager playerManager;
    public Zombie _zombie;
    public Text HealthTxt;
    void Start()
    {
        GunImg.sprite = _gunManager.GunImage ;
        GunNameTxt.text = _gunManager.GunName;
        BulletNeedTxt.text = _gunManager.BulletNeed.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        BulletAmountTxt.text = _gunManager.BulletAmount.ToString();
        HealthSlider.value = playerManager.PlayerHealth;
        HealthTxt.text = playerManager.PlayerHealth.ToString();
        Score.text = _zombie.get_ZsDead().ToString();
        GO_Score.text = _zombie.get_ZsDead().ToString();
    }
}
