using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minigame : MonoBehaviour
{
    public GameObject canvas;
    public Bottle bottlePrefab;
    public List<Bottle> bottles;
    public int size;
    public List<string> molecules;
    public Text clueText;
    public List<Clue> clues;
    public Clue currentClue;


    // Start is called before the first frame update
    void Start()
    {
        size = 3;
        bottles = GenerateGrid(size, size, 1.5f);
        molecules = new List<string>{ "CO2", "H2O", "O2", "NaCl", "CH4", "NaOH", "NaBr", "(NH2)2CO", "NaNO2"};
        NameBottles(bottles, molecules);
        ClueSetUp(clues);
        BottleSetUp(bottles, currentClue);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool CheckBottles()
    {
        foreach (Bottle b in bottles)
        {
            Debug.Log(b.shouldBeClicked);
            if (b.shouldBeClicked)
            {
                return false;
            }
        }
        NewClue();
        return true;
    }

    void NewClue()
    {
        currentClue.clueText.gameObject.SetActive(false);
        clues.Remove(currentClue);
        Debug.Log(clues.Count);
        ClueSetUp(clues);
        BottleSetUp(bottles, currentClue);
    }




    public List<Bottle> GenerateGrid(int rows, int cols, float tileSize)
    {;
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

    public void NameBottles(List<Bottle> bottles, List<string> names)
    {
        foreach(Bottle b in bottles)
        {
            string chosenName = names[Random.Range(0, names.Count)];
            b.chemicalName = chosenName;
            b.GetComponentInChildren<Text>().text = chosenName;
            names.Remove(chosenName);
        }
       
    }

    public void ClueSetUp(List<Clue> clues)
    {
        Clue chosenClue = clues[Random.Range(0, clues.Count)];
        chosenClue.clueText.gameObject.SetActive(true);
        currentClue = chosenClue;
    }

    public void BottleSetUp(List<Bottle> bottles, Clue clue)
    {
            Debug.Log(currentClue);
            {
                foreach (Bottle b in bottles)
                {
                    foreach (string m in clue.molecules)
                        if (b.chemicalName == m)
                        {
                            b.shouldBeClicked = true;
                        }
                }
            }
        }
    }

