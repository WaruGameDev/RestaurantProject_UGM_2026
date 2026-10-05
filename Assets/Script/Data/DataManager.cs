using System.Collections.Generic;
using UnityEngine;

public static class DataManager
{
    public static int money;
    public static int clients;

    public static List<MenuItemData> menu = new List<MenuItemData>();

    public static void SaveGame(GameData dataToSave, string slotName)
    {
        string jsonSave = JsonUtility.ToJson(dataToSave);
        PlayerPrefs.SetString(slotName, jsonSave);
        PlayerPrefs.Save();
    }
    public static GameData LoadGame(string slotName)
    {
        if(!PlayerPrefs.HasKey(slotName))
        {
            //no hay data guardadada
            return null;
        }
        string jsonData = PlayerPrefs.GetString(slotName);

        return JsonUtility.FromJson<GameData>(jsonData);

    }
}
