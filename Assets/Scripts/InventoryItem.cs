using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]


[CreateAssetMenu(fileName = "Reward", menuName = "MM/Reward", order = 2)]

public class InventoryItem : ScriptableObject
{

    //public string type;
    public string itemText;
    public Sprite sprite;
    public bool isKey;

}


