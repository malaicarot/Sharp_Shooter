using System;
using System.Collections.Generic;
using Cinemachine;
using StarterAssets;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    [SerializeField] Transform weaponCamera;
    [SerializeField] CinemachineVirtualCamera deathVirtualCamera;
    [SerializeField] GameObject shieldBarParent;
    [SerializeField] Image shieldBarImg;
    [Range(1, 10)][SerializeField] int health = 10;
    [SerializeField] int deathVirtualCameraPriority = 20;
    [SerializeField] GameObject gameOverPanel;


    List<Image> shieldBarList;
    int currentHealth;

    void Awake()
    {
        shieldBarList = new List<Image>();
        currentHealth = health;
        SetShieldBarUI();

    }
    public int GetPlayerHealth
    {
        get { return currentHealth; }
    }



    void SetShieldBarUI()
    {
        for (int i = 0; i < health; i++)
        {
            Image image = Instantiate(shieldBarImg);
            image.transform.SetParent(shieldBarParent.transform);
            shieldBarList.Add(image);

        }
    }

    void DecreaseShieldBar()
    {
        for (int i = 0; i < shieldBarList.Count; i++)
        {
            if (i < currentHealth)
            {
                shieldBarList[i].enabled = true;
            }
            else
            {
                shieldBarList[i].enabled = false;
            }
        }
    }
    public void TakeDamage(int dame)
    {
        currentHealth -= dame;
        DecreaseShieldBar();
        if (currentHealth <= 0)
        {
            PlayerGameOver();
        }
    }

    void PlayerGameOver()
    {
        StarterAssetsInputs starterAssets = FindFirstObjectByType<StarterAssetsInputs>();
        starterAssets.SetCursorState(false);
        weaponCamera.parent = null;
        deathVirtualCamera.Priority = deathVirtualCameraPriority;
        gameOverPanel.SetActive(true);
        SoundSingleton.soundInstance.PlayBackgroundMusic(2);
        Destroy(this.gameObject);
    }
}
