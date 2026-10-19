using UnityEngine;

[System.Serializable]
public abstract class DecisionNode
{
    // Recorre el árbol desde este nodo y devuelve la hoja elegida
    public abstract ActionNode Evaluate(EntityRestorant entity);
}

