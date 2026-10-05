using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class DataDummy : MonoBehaviour
{
    public GameData gameData;
    public int moneyTemp;
    public int clientTemp;

    public List<MenuItemData> menuTemp;

    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            DataManager.clients = clientTemp;
            DataManager.money = moneyTemp;
            DataManager.menu.Clear();
            DataManager.menu.AddRange(menuTemp);

            Debug.Log(DataManager.clients + " " + DataManager.money);
        }
        if (Input.GetKeyDown(KeyCode.S))
            DataManager.SaveGame(gameData, "slot1");

        if (Input.GetKeyDown(KeyCode.L))
            gameData = DataManager.LoadGame("slot1");


    }
}
