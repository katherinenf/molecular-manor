using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minigame : MonoBehaviour
{
    public GameObject canvas;
    public Bottle bottlePrefab;
    public Text clueText;
    public MinigameLevel level;
    
    List<Bottle> bottles;
    ClueData currentClue;
    List<ClueData> clues;

    void Start()
    {
        if (Globals.nextLevel != null)
        {
            level = Globals.nextLevel;
        }
        bottles = GenerateGrid(level.size, level.size, 1.5f);
        NameBottles(bottles, level.molecules);
        clues = new List<ClueData>(level.clues);
        ClueSetUp(clues);
        BottleSetUp(bottles, currentClue);
    }

    bool CheckBottles()
    {
        if (bottles.Count > 1)
        {
            foreach (Bottle b in bottles)
            {
                if (b.shouldBeClicked)
                {
                    return false;
                }
            }
            NewClue();
        }
        if (bottles.Count == 1)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("HallwayScene");
        }
        return true;
    }

    void NewClue()
    {
        clues.Remove(currentClue);
        ClueSetUp(clues);
        BottleSetUp(bottles, currentClue);
    }

    List<Bottle> GenerateGrid(int rows, int cols, float tileSize)
    {
        ;
        List<Bottle> bottles = new List<Bottle>();
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                Bottle bottle = Instantiate(bottlePrefab, canvas.transform);
                bottle.gameManager = this;
                float posX = col * tileSize;
                float posY = row * -tileSize;
                bottle.transform.position = new Vector2(posX, posY + 3);
                bottles.Add(bottle);
            }
        }
        return bottles;
    }

    void NameBottles(List<Bottle> bottles, List<string> allNames)
    {
        List<string> names = new List<string>(allNames);
        foreach (Bottle b in bottles)
        {
            string chosenName = names[Random.Range(0, names.Count)];
            b.chemicalName = chosenName;
            b.GetComponentInChildren<Text>().text = chosenName;
            names.Remove(chosenName);
        }
    }

    public void RemoveBottle(Bottle bottle)
    {
        bottles.Remove(bottle);
        CheckBottles();
    }

    void ClueSetUp(List<ClueData> clues)
    {
        ClueData chosenClue = clues[Random.Range(0, clues.Count)];
        clueText.text = chosenClue.clueText;
        currentClue = chosenClue;
    }

    void BottleSetUp(List<Bottle> bottles, ClueData clue)
    {
        Debug.Log(currentClue);
        foreach (Bottle b in bottles)
        {
            foreach (string m in clue.molecules)
            {
                if (b.chemicalName == m)
                {
                    b.shouldBeClicked = true;
                }
            }
        }
    }
}

