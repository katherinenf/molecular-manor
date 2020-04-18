using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public InventoryItem reward;
    public Inventory inventory;
    public Fader fader;


    public void AddToInventory()
    {
        InventoryItem toAdd = reward;
        //Instantiate(toAdd, inventory.transform);
        Globals.inventory.Add(toAdd);
        fader.FadeOut("HallwayScene");
    }
}
