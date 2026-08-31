using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TableManager : MonoBehaviour
{
    public List<Table> tables;
    public static TableManager instance;

    void Awake()
    {
        instance = this;
    }

    public Table GetFirstTableNotOccupied()
    {        
        foreach(Table table in tables)
        {
            if(!table.isOccupied)
            {
                return table;
            }
        }
        return null;
    }
    public Table GetNearestTable(Vector3 pos)
    {
        Table closest = null;
        float minSqr = float.MaxValue;

        for (int i = 0; i < tables.Count; i++)
        {
            if (tables[i] == null || tables[i].isOccupied) continue;

            float sqr = (tables[i].transform.position - pos).sqrMagnitude;
            if (sqr < minSqr)
            {
                minSqr = sqr;
                closest = tables[i];
            }
        }
        return closest;
    }
}
