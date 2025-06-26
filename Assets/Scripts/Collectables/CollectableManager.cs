using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectableManager : MonoBehaviour
{
    public TextMeshProUGUI coinUI;
    public TextMeshProUGUI gemUI;
    public TextMeshProUGUI sapphireUI;
    public TextMeshProUGUI emeraldUI;

    int coinscollected = 0;

    public void OnEnable()
    {
        Coin.OnCoinCollected += coinCollected;
    }

    public void OnDisable()
    {
        Coin.OnCoinCollected -= coinCollected;
    }

    public void coinCollected()
    {
        coinscollected++;
        coinUI.text = coinscollected.ToString();
    }

    
}
