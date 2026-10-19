using System;
using UnityEngine;

public class ActionNode : DecisionNode
{
    public string actionName;
    Action<EntityRestorant> action;

    public ActionNode(string name, Action<EntityRestorant> action)
    {
        actionName = name;
        this.action = action;
    }
    public override ActionNode Evaluate(EntityRestorant e) => this;
    public void Execute(EntityRestorant e) => action(e);
}
