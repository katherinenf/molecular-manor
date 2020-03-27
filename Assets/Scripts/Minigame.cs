using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Minigame : MonoBehaviour
{
    public GameObject canvas;
    public Bottle bottlePrefab;
    public Text clueText;
    public MinigameLevel level;
    public List<string> inventoryNames;
    public GameObject mistakeMenu;
    public GameObject bottleContainer;
    public Fader fader;
    
    
    List<Bottle> bottles;
    ClueData currentClue;
    List<ClueData> clues;
    int mistakeCounter = 0;
    //InventoryItem inventoryPrefab;

    void Start()
    {
        if (Globals.nextLevel != null)
        {
            level = Globals.nextLevel;
        }
        bottles = GenerateGrid(level.molecules.Count);
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
            InventoryItem toAdd = new InventoryItem();
            Debug.Log(bottles[0].GetComponentInChildren<TextMeshPro>().text);
            /*toAdd.text = bottles[0].GetComponentInChildren<Text>().text;
            toAdd.sprite = bottles[0].GetComponentInChildren<Image>().sprite;
            Globals.inventory.Add(toAdd);*/
            fader.FadeOut("HallwayScene");
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
    List<Bottle> GenerateGrid(int count)
    {
        List<Bottle> bottles = new List<Bottle>();
        for (int i = 0; i < count; i++)
        {
            Bottle bottle = Instantiate(bottlePrefab, bottleContainer.transform);
            bottle.gameManager = this;
            bottles.Add(bottle);

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
            b.GetComponentInChildren<TMP_Text>().text = chosenName;
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
        fader.FadeOut("HallwayScene");
    }

    public void ResetPuzzle()
    {
        List<Bottle> currentBottles = bottles;
        foreach (Bottle b in currentBottles)
        {
            Destroy(b.gameObject);
        }
        bottles = GenerateGrid(level.molecules.Count);
        NameBottles(bottles, level.molecules);
        clues = new List<ClueData>(level.clues);
        ClueSetUp(clues);
        BottleSetUp(bottles, currentClue);
        mistakeCounter = 0;
        mistakeMenu.SetActive(false);
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

