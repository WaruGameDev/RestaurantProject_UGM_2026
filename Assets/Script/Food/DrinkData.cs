using UnityEngine;
[CreateAssetMenu(fileName = "Dish",
    menuName = "EntityRestorant/DrinkData")]
public class DrinkData : MenuItemData
{
    public bool isLarge;

    public override int GetPrice()
    {
        if(isLarge) return basePrice + 500;        
        return basePrice;
    }

}
