using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallwayManager : MonoBehaviour
{
    public Character gizmo;
    public Fader fader;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlayHallwaySequence());
    }

    // Play the intro sequence coroutine
    public IEnumerator PlayHallwaySequence()
    {
        yield return fader.PlayFadeIn();
        if (!Globals.hallwayTutorialCompleted)
        {
            gizmo.StartTutorial();
            while (gizmo.coroutine != null)
            {
                yield return null;
            }
            Globals.hallwayTutorialCompleted = true;
        }
    }
}
