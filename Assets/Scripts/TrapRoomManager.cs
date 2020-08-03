using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TrapRoomManager : MonoBehaviour
{
    public bool isSolved = false;
    public Key reward;
    public GameObject questionBox;
    public GameObject invItemPrefab;
    public GameObject trap;
    public GameObject newInventoryItem;
    public InventoryItem inventoryReference;
    public GameObject missingBox;
    public Fader fader;
    public Image background;
    public TrapRoom trapRoom;

    public void Start()
    {
        if (Globals.nextTrapRoom != null)
        {
            trapRoom = Globals.nextTrapRoom;
        }

        background.sprite = trapRoom.background;
    }

    public void SolveTrap()
    {
        if(Globals.inventory.Count > 0)
        {
            foreach (InventoryItem i in Globals.inventory)
            {
                if (i.name == trapRoom.solution.name)
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
            if (i.name == trapRoom.solution.name)
            {
                Globals.inventory.Remove(i);
                break;
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

