using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public Inventory inventory;
    public Fader fader;
    public bool isCLickable = false;
    public TrapRoomManager manager;

    public void AddToInventory()
    {
        if (isCLickable)
        {
            InventoryItem toAdd = manager.trapRoom.reward;
            Globals.inventory.Add(toAdd);
            Debug.Log("Size " + Globals.inventory.Count);
            fader.FadeOut("HallwayScene");
        }
        else
        {
            Debug.Log("uhm no");
        }
    }
}
