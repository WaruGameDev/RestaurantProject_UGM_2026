using System.Collections.Generic;
using UnityEngine;

public static class DataManager
{
    //una sola clave de PlayerPrefs para toda la partida
    const string saveKey = "gameData";
    public static GameData gameData = new GameData();

    public static List<MenuItemData> menu = new List<MenuItemData>();

    public static void AddStat(string key, int amount)
    {
        if(gameData.stats.ContainsKey(key))
        {
            gameData.stats[key] += amount;
        }
        else
        {
            gameData.stats.Add(key, amount);
        }
    }
    public static int GetStat(string key)
    {
        if(gameData.stats.ContainsKey(key))
        {
            return gameData.stats[key];
        }
        return 0;
    }
    public static void Save()
    {
        SaveGame(gameData, saveKey);
    }
    public static void Load()
    {
        gameData = LoadGame(saveKey);
        //si no hay data guardada, partimos de cero
        if(gameData == null) gameData = new GameData();
    }

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
