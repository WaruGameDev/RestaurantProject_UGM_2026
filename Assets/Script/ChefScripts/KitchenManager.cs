using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.Cinemachine.CinemachineTriggerAction.ActionSettings;

[Serializable]
public class ClientOrder
{
    public Client currentClient;
    // el ítem del menú que pidió el cliente (DishData o DrinkData)
    public MenuItemData food;
}

public class KitchenManager : MonoBehaviour
{    
    public Transform cookingPosition;
    public Transform deliveryPosition;
    public Transform restPostion;
    public static KitchenManager instance;
    // ítems que los clientes pueden pedir, se asignan en el Inspector
    public List<MenuItemData> menu;
    public List<ClientOrder> clientOrders;
    public List<ClientOrder> readyClientOrders;

    [Header("Decision helper")]
    public float fastDishTime = 4;
  

    void Awake()
    {
        instance = this;
    }
    public bool CheckHaveOrder()
    {
        return clientOrders.Count>0;
    }    
    public void AddFoodOrder(ClientOrder clientOrder)
    {       
        clientOrders.Add(clientOrder);
    }
    public void AddFoodOrderReady(ClientOrder clientOrder)
    {
        readyClientOrders.Add(clientOrder);        
    }
    public ClientOrder LookForClientOrder(Client client)
    {
        foreach(ClientOrder c in readyClientOrders)
        {
            if(c.currentClient == client)
            {
                return c;
            }
        }
        return null;
    }

    public bool HasPendingDrink()
    => clientOrders.Exists(o => o.food is DrinkData);

    public bool HasFastDish()
        => clientOrders.Exists(o => o.food.prepTime <= fastDishTime);

    public ClientOrder TakeFirstDrink()
    {
        ClientOrder order = clientOrders.Find(o => o.food is DrinkData);
        clientOrders.Remove(order);
        return order;
    }

    public ClientOrder TakeFirstOrder()
    {
        ClientOrder order = clientOrders[0];
        clientOrders.RemoveAt(0);
        return order;
    }
    public ClientOrder TakeFastestOrder()
    {
        ClientOrder fastest = clientOrders[0];
        foreach (ClientOrder o in clientOrders)
        {
            if (o.food.prepTime < fastest.food.prepTime)
                fastest = o;
        }
        clientOrders.Remove(fastest);
        return fastest;
    }



}
