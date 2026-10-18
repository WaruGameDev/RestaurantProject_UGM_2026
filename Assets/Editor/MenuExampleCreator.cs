using UnityEditor;
using UnityEngine;

// Herramienta de editor: crea los ítems de menú de ejemplo en Assets/Data/Menu
public static class MenuExampleCreator
{
    const string menuFolder = "Assets/Data/Menu";

    [MenuItem("Restaurante/Crear menú de ejemplo")]
    public static void CreateExampleMenu()
    {
        if (!AssetDatabase.IsValidFolder("Assets/Data"))
            AssetDatabase.CreateFolder("Assets", "Data");
        if (!AssetDatabase.IsValidFolder(menuFolder))
            AssetDatabase.CreateFolder("Assets/Data", "Menu");

        DishData lomo = GetOrCreate<DishData>("LomoALoPobre");
        lomo.itemName = "Lomo a lo pobre";
        lomo.prepTime = 8;
        lomo.basePrice = 8000;
        lomo.isVegetarian = false;
        EditorUtility.SetDirty(lomo);

        DishData ensalada = GetOrCreate<DishData>("EnsaladaChilena");
        ensalada.itemName = "Ensalada chilena";
        ensalada.prepTime = 4;
        ensalada.basePrice = 5000;
        ensalada.isVegetarian = true;
        EditorUtility.SetDirty(ensalada);

        DrinkData jugo = GetOrCreate<DrinkData>("JugoNaturalGrande");
        jugo.itemName = "Jugo natural grande";
        jugo.prepTime = 2;
        jugo.basePrice = 2000; // GetPrice() le suma 500 por ser grande
        jugo.isLarge = true;
        EditorUtility.SetDirty(jugo);

        AssetDatabase.SaveAssets();
        EditorGUIUtility.PingObject(lomo);
        Debug.Log("Menú de ejemplo creado en " + menuFolder);
    }

    // si el asset ya existe lo reutilizamos, así no cambia su GUID
    // y no se pierden las referencias que ya tenga el KitchenManager
    static T GetOrCreate<T>(string fileName) where T : MenuItemData
    {
        string path = menuFolder + "/" + fileName + ".asset";
        T item = AssetDatabase.LoadAssetAtPath<T>(path);
        if (item == null)
        {
            item = ScriptableObject.CreateInstance<T>();
            AssetDatabase.CreateAsset(item, path);
        }
        return item;
    }
}
