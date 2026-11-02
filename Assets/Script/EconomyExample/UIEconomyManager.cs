using System;
using TMPro;
using UnityEngine;

public class UIEconomyManager : MonoBehaviour
{
    public static UIEconomyManager instance;
    public TextMeshProUGUI moneyText;

    private void Start()
    {
        EconomyManager.instance.onAddMoney += RefreshUI;
    }

    private void Awake()
    {
        instance = this;
    }
    public void RefreshUI()
    {
        moneyText.text = EconomyManager.instance.money.ToString();
    }
    
}
