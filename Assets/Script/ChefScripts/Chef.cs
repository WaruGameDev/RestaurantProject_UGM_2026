using UnityEngine;

public class Chef : EntityRestorant
{
    public ClientOrder currentOrder;

    void Start()
    {
        // ClientOrder es Serializable, así que Unity crea una instancia vacía desde el Inspector.
        // Lo dejamos en null para que "no tengo pedido" sea simplemente currentOrder == null.
        currentOrder = null;
        ChangeState(new WaitingFoodOrder());
    }
}
