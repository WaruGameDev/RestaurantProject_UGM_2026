using UnityEngine;

public class Paying : IState
{
    public float timeToPay = 1;
    float currentTime =0;
    Client client;
    public void Enter(EntityRestorant entity)
    {
        client = entity as Client;
        currentTime = timeToPay;
    }

    public void Exit(EntityRestorant entity)
    {
        
    }

    public void InState(EntityRestorant entity)
    {
        if(currentTime > 0)
        {
            currentTime-=1*Time.deltaTime; 
            if(currentTime <= 0)
            {
                // aquí interviene el Mesero
                int price = client.clientOrder.food.GetPrice();
                DataManager.AddStat("dinero", price);
                DataManager.AddStat("clientes", 1);
                Debug.Log("pagó $" + price);
                entity.ChangeState(new Leaving());
            }           
        }
    }
}
