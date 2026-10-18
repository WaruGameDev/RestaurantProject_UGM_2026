using UnityEngine;

public class RestaurantGame : MonoBehaviour
{
    void Awake()
    {
        //recuperamos las estadísticas de la partida anterior
        DataManager.Load();
    }

    void OnApplicationQuit()
    {
        //en el editor también se llama al detener Play
        DataManager.Save();
    }

    //se puede llamar desde un botón de la UI
    public void EndDay()
    {
        DataManager.AddStat("dias", 1);
        DataManager.Save();
        Debug.Log("terminó el día " + DataManager.GetStat("dias"));
    }
}
