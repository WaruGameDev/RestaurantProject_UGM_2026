using System;
using UnityEngine;

public class Chef : EntityRestorant
{
    public ClientOrder currentOrder;
    public DecisionNode decisionTree;

    void Start()
    {
        // ClientOrder es Serializable, así que Unity crea una instancia vacía desde el Inspector.
        // Lo dejamos en null para que "no tengo pedido" sea simplemente currentOrder == null.
        currentOrder = null;
        decisionTree = BuildTree();
        ChangeState(new WaitingFoodOrder());
    }

    private DecisionNode BuildTree()
    {
        KitchenManager k = KitchenManager.instance;

        ActionNode cookDrink = new ActionNode("Preparar bebida",
            e => StartOrder(k.TakeFirstDrink()));
        ActionNode cookFast = new ActionNode("Preparar el más rápido",
            e => StartOrder(k.TakeFastestOrder()));
        ActionNode cookFirst = new ActionNode("Preparar el primero",
            e => StartOrder(k.TakeFirstOrder()));
        ActionNode rest = new ActionNode("Descansar",
            e => meshAgent.SetDestination(k.restPostion.position));

        Decision anyOrder = new Decision(
            e => k.CheckHaveOrder(), cookFirst, rest);

        Decision fastDish = new Decision(
            e => k.HasFastDish(), cookFast, anyOrder);

        Decision root = new Decision(
            e => k.HasPendingDrink(), cookDrink, fastDish);

        return root;

    }

    void StartOrder(ClientOrder order)
    {
        currentOrder = order;
        Debug.Log("El Chef prepara: " + order.food.itemName);
        meshAgent.SetDestination(KitchenManager.instance.cookingPosition.position);
    }

}
