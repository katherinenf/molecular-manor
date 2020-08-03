using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Character : MonoBehaviour
{

    public List<string> directions;
    public GameObject character;
    public GameObject continueButton;
    public GameObject backButton;
    public Coroutine coroutine;

    private bool nextClicked;
    private Typewriter typewriter;
    public bool tutorialCompleted;

    // Start is called before the first frame update
    void Start()
    {
        typewriter = this.GetComponent<Typewriter>();
        coroutine = StartCoroutine(RunConversation());
    }

    public void DirectionsClick()
    {
        nextClicked = true;
    }

    public void SkipTutorial()
    {
        
        StopCoroutine(coroutine);
        coroutine = null;
        character.SetActive(false);
    }

    public IEnumerator RunConversation()
    {
        foreach (string d in directions)
        {
            continueButton.SetActive(false);
            yield return typewriter.PlayText(d);
            continueButton.SetActive(true);
            yield return WaitForNextClick();
        }
        SkipTutorial();

    }

    public IEnumerator WaitForNextClick()
    {
        nextClicked = false;
        while (!nextClicked)
        {
            yield return null;
        }
    }

}
