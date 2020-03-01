using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour
{
    public bool shouldBeClicked;
    public string chemicalName;
    public bool hasBeenClicked;
    public Minigame gameManager;

    // Start is called before the first frame update
    void Awake()
    {
        shouldBeClicked = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BottleClick()
    {
        if (this.GetComponent<Bottle>().shouldBeClicked)
        {
            Destroy(this.gameObject);
            gameManager.CheckBottles();
            gameManager.bottles.Remove(this);
        }
    }




}
