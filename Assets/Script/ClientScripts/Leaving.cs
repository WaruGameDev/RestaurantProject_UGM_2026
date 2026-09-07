using UnityEngine;

public class Leaving : IState
{

    public void Enter(EntityRestorant entity)
    {
        entity.meshAgent.SetDestination(TableManager.instance.door.position);
        Client client = entity as Client;
        client.currentTable.SetOccupied(false);
        TableManager.instance.ClearTable(client.currentTable);
       
    }

    public void Exit(EntityRestorant entity)
    {
        
    }

    public void InState(EntityRestorant entity)
    {
       
    }
}
