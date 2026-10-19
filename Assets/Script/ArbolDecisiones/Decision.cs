using System;
using UnityEngine;

public class Decision : DecisionNode
{
    Func<EntityRestorant, bool> question;
    DecisionNode yesNode, noNode;

    public Decision(Func<EntityRestorant, bool> q,
                    DecisionNode yes, DecisionNode no)
    {
        question = q;
        yesNode = yes;
        noNode = no;
    }
    public override ActionNode Evaluate(EntityRestorant entity)
    {
        if (question(entity))
            return yesNode.Evaluate(entity);
        return noNode.Evaluate(entity);
    }
}
