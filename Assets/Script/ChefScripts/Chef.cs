using UnityEngine;

public class Chef : EntityRestorant
{
    public ClientOrder currentOrder;

    void Start()
    {
        ChangeState(new WaitingFoodOrder());
    }
}
