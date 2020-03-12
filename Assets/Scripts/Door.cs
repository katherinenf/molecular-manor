using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public MinigameLevel level;    

    // assigns level and loads minigame scene
    public void ButtonClicked()
    {
        Globals.nextLevel = level;
        UnityEngine.SceneManagement.SceneManager.LoadScene("MiniGameScene");
        
    }




}
