using System;
using UnityEngine;

public class EconomyManager : MonoBehaviour
{
    public static EconomyManager instance;
    public Action onAddMoney;
    public int money;

    private void Awake()
    {
        instance = this;
    }
    public void AddMoney(int moneyToAdd)
    {
        money += moneyToAdd;
        onAddMoney?.Invoke();
    }

    private void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            AddMoney(1);
        }
    }

}
