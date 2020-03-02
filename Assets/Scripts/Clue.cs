using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Clue : MonoBehaviour
{
    public Text clueText;
    public List<string> molecules;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*public void SetUp(List<string> clues, List<List<Bottle>> bottlesToClick)
    {  
        string currentClue = clues[Random.Range(0, clues.Count)];
        this.GetComponentInChildren<Text>().text = currentClue;
        clues.Remove(currentClue);
        }

    }*/
}
