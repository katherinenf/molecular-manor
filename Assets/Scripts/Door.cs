using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

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
    public Image windowImage;
    public Sprite completeSprite;
    public Texture2D hoverCursor;
    public GameObject indicatorPrefab;
    RectTransform rect;
    Button button;

    public void Start()
    {
        rect = GetComponent<RectTransform>();
        button = GetComponent<Button>();

        // Become unclickable and use the green window if this room is complete
        if (IsComplete())
        {
            windowImage.sprite = completeSprite;
            button.interactable = false;
        }
    }

    // Called by the hallway manager when gameplay has begun after the tutorial
    public void OnStartGameplay()
    {
        if (!IsComplete())
        {
            // Spawn the proper door indicator into the appropriate parent container
            GameObject indicator = Instantiate(indicatorPrefab, GameObject.Find("DoorIndicators").transform);
            indicator.GetComponent<RectTransform>().anchoredPosition = rect.anchoredPosition + new Vector2(0, 230);
        }
    }

    // assigns level and loads minigame scene
    public void ButtonClicked()
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

    // Swap the cursor texture when the mouse is over the door
    public void OnPointerEnter()
    {
        if (button.interactable)
        {
#if UNITY_WEBGL
            Vector2 hotSpot = new Vector2(hoverCursor.width, 0) / 2;
            Cursor.SetCursor(hoverCursor, hotSpot, CursorMode.ForceSoftware);
#else
            Cursor.SetCursor(hoverCursor, Vector2.zero, CursorMode.Auto);
#endif
        }
    }

    // Return the cursor to normal when the mouse leaves the door
    public void OnPointerExit()
    {
        if (button.interactable)
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }
    }
}
