using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]


[CreateAssetMenu(fileName = "TrapRoom", menuName = "MM/TrapRoom", order = 2)]
public class TrapRoom : ScriptableObject
{
    public InventoryItem solution;
    public InventoryItem reward;
    public Sprite background;
}
