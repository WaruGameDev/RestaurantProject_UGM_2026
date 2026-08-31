using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class Table : MonoBehaviour
{
    public bool isOccupied;
    
    public void SetOccupied(bool _isOccupied)
    {
        isOccupied = _isOccupied;
    }
}
