using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class TrapRoomManager : MonoBehaviour
{

    public bool isSolved = false;
    public InventoryItem solution;
    public Key reward;
    public GameObject questionBox;
    public GameObject invItemPrefab;
    public GameObject trap;
    public GameObject newInventoryItem;
    public InventoryItem inventoryReference;
    public GameObject missingBox;
    public Fader fader;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SolveTrap()
    {
        if(Globals.inventory.Count > 0)
        {
            foreach (InventoryItem i in Globals.inventory)
            {
                if (i.name == solution.name)
                {
                    questionBox.SetActive(true);
                    inventoryReference = i;
                    newInventoryItem = Instantiate(invItemPrefab, questionBox.transform);
                    newInventoryItem.GetComponentInChildren<TMP_Text>().text = inventoryReference.itemText;
                    newInventoryItem.GetComponentInChildren<Image>().sprite = inventoryReference.sprite;
                }
                else
                {
                    missingBox.SetActive(true);
                }
            }
        }
        else
        {
            missingBox.SetActive(true);
        }

    }

    public void SolveTrapButton()
    {
        questionBox.SetActive(false);
        trap.SetActive(false);
        reward.isCLickable = true;
    }

    public void GetReward()
    {
        isSolved = true;
        foreach (InventoryItem i in Globals.inventory)
        {
            if (i.name == solution.name)
            {
                Globals.inventory.Remove(i);
            }
        }
    }

    public void BackButton()
    {
        fader.FadeOut("HallwayScene");
    }

    public void CloseButton()
    {
        missingBox.SetActive(false);
    }
}

