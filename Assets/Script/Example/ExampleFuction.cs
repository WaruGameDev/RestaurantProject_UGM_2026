using System;
using UnityEngine;

public class ExampleFuction : MonoBehaviour
{
    private int V = 0;
    Func<int, bool> example = V => true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        Func<EntityRestorant, bool> hayPedidos =
    e => KitchenManager.instance.CheckHaveOrder();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
