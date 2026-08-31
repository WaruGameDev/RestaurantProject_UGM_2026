using UnityEngine;

public class Client : EntityRestorant
{
    void Start()
    {
        ChangeState(new WaitingForTable());
    }
}
