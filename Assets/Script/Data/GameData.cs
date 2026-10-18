using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class GameData : ISerializationCallbackReceiver
{
    public string namePlayer;
    //estadísticas del restaurante: "dinero", "clientes", "dias"...
    //JsonUtility no sabe guardar un Dictionary, por eso lo copiamos a las listas espejo
    public Dictionary<string, int> stats = new Dictionary<string, int>();

    //listas espejo: keys[i] va con values[i]. Estas sí las guarda JsonUtility
    public List<string> keys = new List<string>();
    public List<int> values = new List<int>();
    //inserte las variables de guardado

    //antes de guardar: pasamos el diccionario a las listas
    public void OnBeforeSerialize()
    {
        keys.Clear();
        values.Clear();
        foreach(KeyValuePair<string, int> stat in stats)
        {
            keys.Add(stat.Key);
            values.Add(stat.Value);
        }
    }

    //después de cargar: armamos el diccionario desde las listas
    public void OnAfterDeserialize()
    {
        stats = new Dictionary<string, int>();
        for(int i = 0; i < keys.Count && i < values.Count; i++)
        {
            stats[keys[i]] = values[i];
        }
    }
}
