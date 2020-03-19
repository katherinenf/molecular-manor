using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public MinigameLevel level;
    public Fader fader;

    // assigns level and loads minigame scene
    public void ButtonClicked()
    {
        Globals.nextLevel = level;
        fader.FadeOut("MiniGameScene", transform.position);
    }

}
