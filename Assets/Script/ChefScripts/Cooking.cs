using UnityEngine;

public class Cooking : IState
{
    public float currentTimeToCook =0;
    public void Enter(EntityRestorant entity)
    {
        // cada ítem del menú tiene su propio tiempo de preparación
        Chef chef = entity as Chef;
        Debug.Log("cooking " + chef.currentOrder.food.itemName);
        currentTimeToCook = chef.currentOrder.food.prepTime;
    }

    public void Exit(EntityRestorant entity)
    {
        
    }

    public void InState(EntityRestorant entity)
    {
        // si el ítem tiene prepTime 0, se entrega en el primer frame
        currentTimeToCook-=1*Time.deltaTime;
        if(currentTimeToCook<= 0)
        {
            entity.ChangeState(new Delivering());
        }
    }
}
