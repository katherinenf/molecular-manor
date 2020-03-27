using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject invBottle;

    // Start is called before the first frame update
    void Start()
    {
        if (Globals.inventory != null)
        {

            foreach (InventoryItem i in Globals.inventory)
            {
                GameObject newInventoryItem = Instantiate(invBottle, this.transform);
                newInventoryItem.GetComponentInChildren<Text>().text = i.text;
                newInventoryItem.GetComponentInChildren<Image>().sprite = i.sprite;
            }
        }
        else
        {
            Debug.Log("nothing to see here");
        }
    }



/*    void AddBottleToInventory()
    {
        foreach (string t in Globals.inventoryTexts)
        {
            GameObject added = Instantiate(invBottlePrefab, this.transform);
            added.GetComponentInChildren<Text>().text = t;
        }
    }*/
}
