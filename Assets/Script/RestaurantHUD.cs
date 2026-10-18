using TMPro;
using UnityEngine;

public class RestaurantHUD : MonoBehaviour
{
    public TMP_Text moneyText;
    public TMP_Text clientsText;

    void Update()
    {
        moneyText.text = "Dinero: $" + DataManager.GetStat("dinero");
        clientsText.text = "Clientes: " + DataManager.GetStat("clientes");
    }
}
