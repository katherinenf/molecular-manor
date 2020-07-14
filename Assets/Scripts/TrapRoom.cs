using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]


[CreateAssetMenu(fileName = "TrapData", menuName = "MM/TrapData", order = 2)]

public class TrapRoom : ScriptableObject
{

    //public string type;
    public InventoryItem reward;
    public Image background;
    //public BoobyTrap trap;

}
