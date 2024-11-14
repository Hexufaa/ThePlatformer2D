using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ItemManager : MonoBehaviour
{
    public TMP_Text coinText;
    public TMP_Text OrbText;

    public static ItemManager Instance;
    public SOInt coins;
    public SOInt orbs;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        coins.value = 0;
        orbs.value = 0;
    }

    public void AddCoins(int amount = 1)
    {
        coins.value += amount;
        UpdateCoinText();
    }
    
    private void UpdateCoinText()
    {
        if (coinText != null)
        {
            coinText.text = "Coins: " + coins.value.ToString();
        }
    }
    //____________________________________ORBS

    public void AddOrbs(int amount = 1)
    {
        orbs.value += amount;
        UpdateOrbText();
    }

    private void UpdateOrbText()
    {
        if (OrbText != null)
        {
            OrbText.text = "Orbs: " + orbs.value.ToString();
        }
    }
    //________________________________________ORBS
}
