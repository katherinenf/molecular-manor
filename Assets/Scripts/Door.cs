using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public MinigameLevel level;    


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
        Globals.nextLevel = level;
        UnityEngine.SceneManagement.SceneManager.LoadScene("MiniGameScene");
        
    }




}
