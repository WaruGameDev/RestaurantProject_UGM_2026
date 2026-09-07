using UnityEngine;

public class Cooking : IState
{
    public void Enter(EntityRestorant entity)
    {
        // timer de tiempo de cocina
        Debug.Log("cooking");
    }

    public void Exit(EntityRestorant entity)
    {
        
    }

    public void InState(EntityRestorant entity)
    {
        // al terminar el timer debe ir a dejar a la mesa
    }
}
