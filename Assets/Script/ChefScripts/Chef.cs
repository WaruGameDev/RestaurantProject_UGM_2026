using UnityEngine;

public class Chef : EntityRestorant
{
    public string currentOrder;

    void Start()
    {
        ChangeState(new WaitingFoodOrder());
    }
}
