using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class TableRestorant
{
    public Table table;
    public Client client;   
}

public class TableManager : MonoBehaviour
{
    public List<TableRestorant> tables;
    public static TableManager instance;
    public Transform door;

    void Awake()
    {
        instance = this;
    }

    public TableRestorant GetFirstTableNotOccupied()
    {        
        foreach(TableRestorant table in tables)
        {
            if(!table.table.isOccupied)
            {
                return table;
            }
        }
        return null;
    }
    public TableRestorant GetNearestTable(Vector3 pos)
    {
        TableRestorant closest = null;
        float minSqr = float.MaxValue;

        for (int i = 0; i < tables.Count; i++)
        {
            if (tables[i] == null || tables[i].table.isOccupied) continue;

            float sqr = (tables[i].table.transform.position - pos).sqrMagnitude;
            if (sqr < minSqr)
            {
                minSqr = sqr;
                closest = tables[i];
            }
        }
        return closest;
    }
    public void ClearTable(Table table)
    {
        foreach(TableRestorant tableRestorant in tables)
        {
            if(tableRestorant.table == table)
            {
                tableRestorant.client = null;
            }
        }
    }
}
