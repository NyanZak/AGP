using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public TMP_Text coinText;
    public int currentCoins = 0;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        coinText.text = "" + currentCoins.ToString(); 
    }

    public void IncreaseCoins(int v)
    {
        currentCoins += v;
        coinText.text = "" + currentCoins.ToString();
    }

}
