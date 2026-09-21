using UnityEngine;

public class WaitingForOrder : IState
{
    Client client;
    public void Enter(EntityRestorant entity)
    {
        client = entity as Client;
        KitchenManager.instance.AddFoodOrder(client.clientOrder);
    }

    public void Exit(EntityRestorant entity)
    {
       
    }

    public void InState(EntityRestorant entity)
    {
        if(KitchenManager.instance.LookForClientOrder(client)== null) return;      
        //quizas mantener el plato en el jugador o en algun lugar para guardar el precio
        KitchenManager.instance.readyClientOrders.Remove(KitchenManager.instance.LookForClientOrder(client));
        entity.ChangeState(new Eating());
    }
}

