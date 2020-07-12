﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject invItemPrefab;
    //public GameObject container;

    // Start is called before the first frame update
    void Start()
    {
        if (Globals.inventory.Count > 0)
        {
            foreach (InventoryItem i in Globals.inventory)
            {
                GameObject newInventoryItem = Instantiate(invItemPrefab, this.gameObject.transform);
                newInventoryItem.GetComponentInChildren<Text>().text = i.itemText;
                newInventoryItem.GetComponentInChildren<Image>().sprite = i.sprite;
            }
        }
    }

}