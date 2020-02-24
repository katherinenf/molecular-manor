using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame : MonoBehaviour
{

    public GameObject bottlePrefab;
    public List<GameObject> clues;
    public List<GameObject> bottles;
    public int size;

    // Start is called before the first frame update
    void Start()
    {
        bottles = GenerateGrid(size, size, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*Onclick(bottle)
    {
        If(!shouldBeEliminated(bottle)) doBadThing()
        else if (currentHintSatisified) goToNextHint()
    }*/

    public List<GameObject> GenerateGrid(int rows, int cols, float tileSize, float offSet)
    {
        List<GameObject> bottles = new List<GameObject>();

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                GameObject bottle;
                bottle = Instantiate(bottlePrefab, transform);
                float posX = col * tileSize;
                float posY = row * -tileSize;
                bottle.transform.position = new Vector2(posX + offSet, posY + 3);
                bottles.Add(bottle);
            }
        }
        return bottles;
    }
}
