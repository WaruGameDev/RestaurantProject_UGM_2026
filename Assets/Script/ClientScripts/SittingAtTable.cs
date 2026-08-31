using Unity.VisualScripting;
using UnityEngine;

public class SittingAtTable : IState
{
    public Food order;
    public float timeToOrder = 2;
    float currentTime =0;
   
    /* public SittingAtTable(Food _food, float _timeToOrder)
    {
        order = _food;
        timeToOrder = _timeToOrder;
    }*/
    public void Enter(EntityRestorant entity)
    {
        currentTime = timeToOrder;
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
                //change To Pedir
                Debug.Log("va a pedir");
                //por temas de que nos falta el mesero, comemos directamente.
                entity.ChangeState(new Eating());
            }           
        }
    }
}
