using System.Collections.Generic;
using UnityEngine;

public class KitchenManager : MonoBehaviour
{
    public List<string> order;
    public Transform cookingPosition;
    public Transform deliveryPosition;
    public Transform restPostion;
    public static KitchenManager instance;

    void Awake()
    {
        instance = this;
    }
    public bool CheckHaveOrder()
    {
        return order.Count>0;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            order.Add("pizza");
        }
    }
}
