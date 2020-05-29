﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public MinigameLevel level;
    public Fader fader;
    public string type;
    // assigns level and loads minigame scene
    public void ButtonClicked()
    {
        if (type == "minigame")
        {
            Globals.nextLevel = level;
            fader.FadeOut("MiniGameScene", transform.position);
        }
        if(type == "trap")
        {
            fader.FadeOut("TrapRoom1");
        }
    }

}
