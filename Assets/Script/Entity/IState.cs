using UnityEngine;

public interface IState
{
    void Enter(EntityRestorant entity);
    void InState(EntityRestorant entity);
    void Exit(EntityRestorant entity);
}
