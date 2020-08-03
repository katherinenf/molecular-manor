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
    public GameObject mistakeMenu;
    public GameObject bottleContainer;
    public Fader fader;
    public Inventory inventory;
    public bool bottlesClickable;
    public Character widgetTutorial;
    public Character widgetClues;
    public List<GameObject> hints;
    public GameObject hintBox;
    public GameObject hintPrefab;
    public int mistakeNumber;
    
    
    List<Bottle> bottles;
    ClueData currentClue;
    List<ClueData> clues;
    int mistakeCounter = 0;

    void Start()
    {
        mistakeNumber = 0;
        if (Globals.nextLevel != null)
        {
            level = Globals.nextLevel;
        }
        bottles = GenerateGrid(level.molecules.Count);
        NameBottles(bottles, level.molecules);
        clues = new List<ClueData>(level.clues);
        bottlesClickable = false;
        StartCoroutine(PlayMinigameSequence());
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
            InventoryItem toAdd = Instantiate(level.reward, inventory.transform);
            Globals.inventory.Add(toAdd);
            toAdd.name = level.reward.name;
            toAdd.name = level.reward.name;
            Globals.completeMinigames.Add(level);
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

    public void RemoveBottle(Bottle bottle)
    {
        bottles.Remove(bottle);
        CheckBottles();
    }

    // if a bottle should not have been clicked updates the mistakeCounter, removes a hint, and displays mistake panel if > 3
    public void mistake()
    {
        mistakeCounter++;
        hints[mistakeNumber].SetActive(false);
        mistakeNumber++;
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
        HintRefill();
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


    public void HintRefill()
    {
        for(int i = 0; i <= mistakeNumber; i++)
        {
            hints[i].SetActive(true);       
        }
    }

    public IEnumerator PlayMinigameSequence()
    {
        yield return fader.PlayFadeIn();
        if (!Globals.minigameTutorialCompleted)
        {
            widgetTutorial.StartTutorial();
            while (widgetTutorial.coroutine != null)
            {
                yield return null;
            }
            Globals.minigameTutorialCompleted = true;
        }
        ClueSetUp(clues);
        BottleSetUp(bottles, currentClue);
        widgetClues.gameObject.SetActive(true);
        widgetTutorial.gameObject.SetActive(false);
        bottlesClickable = true;

    }
}

