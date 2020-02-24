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


}
