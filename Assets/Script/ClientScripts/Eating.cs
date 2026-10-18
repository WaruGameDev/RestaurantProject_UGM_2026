using UnityEngine;

public class Eating : IState
{
    public float timeToEat = 2;
    float currentTime =0;
    public void Enter(EntityRestorant entity)
    {
        currentTime = timeToEat;
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
                Debug.Log("termino de comer");
                //antes de irse, paga lo que comió
                entity.ChangeState(new Paying());
            }           
        }
    }
}
