using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public int difficulty;
    public List<GameObject> questions;
    public List<GameObject> chemicals;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonClicked()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MiniGameScene");
        
    }


    public void GoToRoom()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("roomScene");
    }

    public List<GameObject> GenerateGrid(int rows, int cols, float tileSize, float offSet)
    {
        List<GameObject> crusts = new List<GameObject>();

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                GameObject bottle;
                float type = UnityEngine.Random.Range(0, 2);
                if (type == 0)
                {
                    tile = Instantiate(bottlePrefab, transform);
                    float posX = col * tileSize;
                    float posY = row * -tileSize;
                    tile.transform.position = new Vector2(posX + offSet, posY + 3);
                    bottles.Add(bottle);
                }

            }
        }
        return bottles;
    }
}
