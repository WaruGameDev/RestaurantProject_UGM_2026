using UnityEngine;

public class Client : EntityRestorant
{
    public Table currentTable;
    // va a cambiar
    public ClientOrder clientOrder;
    void Start()
    {
        ChangeState(new WaitingForTable());
    }
}
