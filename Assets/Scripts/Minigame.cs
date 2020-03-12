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
    public List<Bottle> inventory;
    public GameObject mistakeMenu;
    public GameObject bottleContainer;
    
    List<Bottle> bottles;
    ClueData currentClue;
    List<ClueData> clues;
    int mistakeCounter = 0;

    void Start()
    {
        if (Globals.nextLevel != null)
        {
            level = Globals.nextLevel;
        }
        inventory = Globals.inventory;
        bottles = GenerateGrid(level.size, level.size, 1.5f);
        NameBottles(bottles, level.molecules);
        clues = new List<ClueData>(level.clues);
        ClueSetUp(clues);
        BottleSetUp(bottles, currentClue);
    }

    // checks shouldBeClicked condition of remaining bottles and advances clues or ends game
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
            Globals.inventory.Add(bottles[0]);
            UnityEngine.SceneManagement.SceneManager.LoadScene("HallwayScene");
        }
        return true;
    }

    // removes current clue from list and chooses a new clue
    void NewClue()
    {
        clues.Remove(currentClue);
        ClueSetUp(clues);
        BottleSetUp(bottles, currentClue);
    }

    // sets up the initial bottle grid
    List<Bottle> GenerateGrid(int rows, int cols, float tileSize)
    {
        ;
        List<Bottle> bottles = new List<Bottle>();
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                Bottle bottle = Instantiate(bottlePrefab, bottleContainer.transform);
                bottle.gameManager = this;
                float posX = col * tileSize;
                float posY = row * -tileSize;
                bottle.transform.position = new Vector2(posX, posY + 3);
                bottles.Add(bottle);
            }
        }
        return bottles;
    }

    // randomly assigns names of molecules to bottles 
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

    // removes a bottle
    public void RemoveBottle(Bottle bottle)
    {
        bottles.Remove(bottle);
        CheckBottles();
    }

    // if a bottle should not have been clicked updates the mistakeCounter and resets the game if >3
    public void mistake()
    {
        mistakeCounter++;
        if (mistakeCounter == 3)
        {
            mistakeMenu.SetActive(true);
        }
        
    }

    public void ExitRoom()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("HallwayScene");
    }

    public void ResetPuzzle()
    {
        List<Bottle> currentBottles = bottles;
        foreach (Bottle b in currentBottles)
        {
            Destroy(b.gameObject);
        }
        bottles = GenerateGrid(level.size, level.size, 1.5f);
        NameBottles(bottles, level.molecules);
        clues = new List<ClueData>(level.clues);
        ClueSetUp(clues);
        BottleSetUp(bottles, currentClue);
        mistakeCounter = 0;
    }

    // randomly chooses a clue
    void ClueSetUp(List<ClueData> clues)
    {
        ClueData chosenClue = clues[Random.Range(0, clues.Count)];
        clueText.text = chosenClue.clueText;
        currentClue = chosenClue;
    }

    // assigns which bottles should be clicked based on clue
    void BottleSetUp(List<Bottle> bottles, ClueData clue)
    {
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

