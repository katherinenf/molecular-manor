using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Gizmo : MonoBehaviour
{

    public List<string> directions;
    public int currentDirection;
    public Text directionText;
    public GameObject gizmo;
    public GameObject bubble;
    public bool doorsClickable;

    // Start is called before the first frame update
    void Start()
    {
        if(Globals.hallwayTutorialCompleted)
        {
            SkipTutorial();
        }
        else
        {
            directionText.text = directions[0];
            doorsClickable = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DirectionsClick()
    {
        if (currentDirection <= directions.Count - 2)
        {
            currentDirection++;
            directionText.text = directions[currentDirection];
        }
        else
        {
            SkipTutorial();
        }
    }

    public void BackClick()
    {
        if (currentDirection > 0)
        {
            currentDirection--;
            directionText.text = directions[currentDirection];

        }
    }

    public void SkipTutorial()
    {
        gizmo.SetActive(false);
        bubble.SetActive(false);
        doorsClickable = true;
        Globals.hallwayTutorialCompleted = true;

    }

}
