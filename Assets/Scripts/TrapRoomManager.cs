using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TrapRoomManager : MonoBehaviour
{

    public bool isSolved = false;
    public InventoryItem solution;
    public Key reward;
    public GameObject questionBox;
    public GameObject invItemPrefab;

    // Start is called before the first frame update
    void Start()
    {
        foreach (InventoryItem i in Globals.inventory)
        {
            if (i.name == solution.name)
            {
                questionBox.SetActive(true);
                GameObject newInventoryItem = Instantiate(invItemPrefab, questionBox.transform);
                newInventoryItem.GetComponentInChildren<Text>().text = i.itemText;
                newInventoryItem.GetComponentInChildren<Image>().sprite = i.sprite;
            }
        }
    }

    public void SolveTrap()
    {
        Debug.Log("I am called");
        questionBox.SetActive(false);
        Debug.Log("play an animation");
        reward.isCLickable = true;
        isSolved = true;
    }
}
