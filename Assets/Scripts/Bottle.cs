using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour
{
    public bool shouldBeClicked;
    public string chemicalName;
    public bool hasBeenClicked;
    public Minigame gameManager;
    public GameObject eliminatedIcon;

    // Start is called before the first frame update
    void Awake()
    {
        shouldBeClicked = false;
    }

    // directs game manager based on whether or not is should be clicked
    public void BottleClick()
    {
        if (gameManager.bottlesClickable)
        {
            if (shouldBeClicked)
            {
                eliminatedIcon.SetActive(true);
                gameManager.RemoveBottle(this);
            }
            if (!shouldBeClicked)
            {
                gameManager.mistake();
            }
        }
    }




}
