using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Globals
{
    public static MinigameLevel nextLevel;

    //texts to go on bottles
    public static List<InventoryItem> inventory = new List<InventoryItem>();
    public static bool hallwayTutorialCompleted;
    public static bool minigameTutorialCompleted;

    // Completed rooms
    public static List<MinigameLevel> completeMinigames = new List<MinigameLevel>();
    public static List<TrapRoom> completedTraps = new List<TrapRoom>();
}
