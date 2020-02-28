using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame : MonoBehaviour
{
    public GameObject canvas;
    public GameObject bottlePrefab;
    public List<GameObject> clues;
    public List<GameObject> bottles;
    public int size;

    // Start is called before the first frame update
    void Start()
    {
        bottles = GenerateGrid(size, size, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(bottles[1].GetComponent<Bottle>().shouldBeClicked);
    }

    /*Onclick(bottle)
    {
        If(!shouldBeEliminated(bottle)) doBadThing()
        else if (currentHintSatisified) goToNextHint()
    }*/



    public List<GameObject> GenerateGrid(int rows, int cols, float tileSize)
    {
        List<GameObject> bottles = new List<GameObject>();

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                GameObject newCanvas = Instantiate(canvas, transform) as GameObject;
                GameObject bottle = Instantiate(bottlePrefab, transform) as GameObject;
                bottle.transform.SetParent(newCanvas.transform, false);
                float posX = col * tileSize;
                float posY = row * -tileSize;
                newCanvas.transform.position = new Vector2(posX, posY + 3);
                bottle.transform.position = new Vector2(posX, posY + 3);
                bottles.Add(bottle);
                if (Random.Range(0,1) > 0)
                {
                    bottle.GetComponent<Bottle>().shouldBeClicked = true;
                }
                else bottle.GetComponent<Bottle>().shouldBeClicked = false;
            }
        }
        return bottles;
    }

}
