using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class ClientOrder
{
    public Client currentClient;
    public string currentOrder;
}

public class KitchenManager : MonoBehaviour
{    
    public Transform cookingPosition;
    public Transform deliveryPosition;
    public Transform restPostion;
    public static KitchenManager instance;
    public List<ClientOrder> clientOrders;
  

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
}
