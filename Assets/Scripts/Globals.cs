using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Globals
{
    public static MinigameLevel nextLevel;
    public static TrapRoom nextTrapRoom;

    //texts to go on bottles
    public static List<InventoryItem> inventory = new List<InventoryItem>();
    public static bool hallwayTutorialCompleted;
    public static bool minigameTutorialCompleted;

    // Completed rooms
    public static List<MinigameLevel> completeMinigames = new List<MinigameLevel>();
    public static List<TrapRoom> completedTraps = new List<TrapRoom>();

    public static void ResetProgress()
    {
        nextLevel = null;
        nextTrapRoom = null;
        inventory.Clear();
        hallwayTutorialCompleted = false;
        minigameTutorialCompleted = false;
        completeMinigames.Clear();
        completedTraps.Clear();
    }

    public static bool HasKeys(int numKeys)
    {
        int keys = 0;
        foreach (InventoryItem item in inventory)
        {
           if (item.isKey)
            {
                keys++;
            }
        }
        return keys == numKeys;
    }
}
