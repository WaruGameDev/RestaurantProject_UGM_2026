using System.Collections.Generic;
using UnityEngine;

public class Client : EntityRestorant
{
    public Table currentTable;
    // se crea por código en ChooseOrder(), no depende del Inspector
    public ClientOrder clientOrder;
    void Start()
    {
        ChangeState(new WaitingForTable());
    }

    public void ChooseOrder()
    {
        clientOrder = new ClientOrder();
        clientOrder.currentClient = this;
        // elige al azar un ítem del menú de la cocina
        List<MenuItemData> menu = KitchenManager.instance.menu;
        clientOrder.food = menu[Random.Range(0, menu.Count)];
    }
}
