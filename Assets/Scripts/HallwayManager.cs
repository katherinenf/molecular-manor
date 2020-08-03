using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallwayManager : MonoBehaviour
{
    public Character gizmo;
    public bool tutorialOn;
    public bool doorsClickable;
    public Fader fader;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlayHallwaySequence());
    }

    public IEnumerator PlayHallwaySequence()
    {
        yield return fader.PlayFadeIn();
        if (!Globals.hallwayTutorialCompleted)
        {
            gizmo.gameObject.SetActive(true);
            yield return gizmo.coroutine;
            doorsClickable = true;
            Globals.hallwayTutorialCompleted = true;
        }
        doorsClickable = true;
        Globals.hallwayTutorialCompleted = true;

    }
}
