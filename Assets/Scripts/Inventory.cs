using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{
    public GameObject invItemPrefab;

    // Start is called before the first frame update
    void Start()
    {
        if (Globals.inventory.Count > 0)
        {
            foreach (InventoryItem i in Globals.inventory)
            {
                GameObject newInventoryItem = Instantiate(invItemPrefab, this.gameObject.transform);
                newInventoryItem.GetComponentInChildren<TMP_Text>().text = i.itemText;
                newInventoryItem.GetComponentInChildren<Image>().sprite = i.sprite;
            }
        }
    }

}
