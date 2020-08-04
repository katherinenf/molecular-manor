using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum RoomType
{
    Minigame,
    Trap
}

public class Door : MonoBehaviour
{
    public RoomType type;
    public MinigameLevel level;
    public TrapRoom trapRoom;
    public Fader fader;
    public HallwayManager hallwayManager;
    public Image windowImage;
    public Sprite completeSprite;
    public Texture2D hoverCursor;

    public void Start()
    {
        // Use the green sprite if this room is complete
        if (IsComplete())
        {
            windowImage.sprite = completeSprite;
        }
    }

    // assigns level and loads minigame scene
    public void ButtonClicked()
    {
        if (hallwayManager.doorsClickable && !IsComplete())
        {
            switch (type)
            {
                case RoomType.Minigame: 
                    {
                        Globals.nextLevel = level;
                        fader.FadeOut("MiniGameScene", transform.position);
                        break;
                    }
                case RoomType.Trap:
                    {
                        Globals.nextTrapRoom = trapRoom;
                        fader.FadeOut("TrapRoomScene", transform.position);
                        break;
                    }
            }
        }
    }

    // Returns truthy if the minigame or trap this door is connected too is complete
    bool IsComplete()
    {
        switch (type)
        {
            case RoomType.Minigame: return Globals.completeMinigames.Contains(level);
            case RoomType.Trap: return Globals.completedTraps.Contains(trapRoom);
        }
        return false;
    }


    public void OnPointerEnter()
    {
        Cursor.SetCursor(hoverCursor, Vector2.zero, CursorMode.Auto);
    }

    public void OnPointerExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
