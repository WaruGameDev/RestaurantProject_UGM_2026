using UnityEngine;

public class Client : EntityRestorant
{
    public Table currentTable;
    void Start()
    {
        ChangeState(new WaitingForTable());
    }
}
