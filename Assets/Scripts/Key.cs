using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public InventoryItem reward;
    public Inventory inventory;
    public Fader fader;
    public bool isCLickable = false;


    public void AddToInventory()
    {
        if (isCLickable)
        {
            InventoryItem toAdd = reward;
            Globals.inventory.Add(toAdd);
            fader.FadeOut("HallwayScene");
        }
        else
        {
            Debug.Log("uhm no");
        }
    }
}
