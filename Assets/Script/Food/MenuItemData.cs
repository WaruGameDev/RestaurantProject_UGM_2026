using UnityEngine;

public abstract class MenuItemData : ScriptableObject
{
    public string itemName;
    public int basePrice;
    public float prepTime;
    public Sprite iconItem;

    public virtual int GetPrice() => basePrice;

}
