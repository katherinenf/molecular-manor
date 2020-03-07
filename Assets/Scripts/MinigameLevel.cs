using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct ClueData
{
    public string clueText;
    public List<string> molecules;
}

[CreateAssetMenu(fileName = "MinigameLevel", menuName = "MM/Minigame Level", order = 1)]
public class MinigameLevel : ScriptableObject
{
    public List<string> molecules;
    public List<ClueData> clues;
    public int size;

}
