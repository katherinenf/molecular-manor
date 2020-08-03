using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Character : MonoBehaviour
{
    public List<string> directions;
    public GameObject character;
    public GameObject bubble;
    public GameObject continueButton;
    public GameObject backButton;
    public Coroutine coroutine;

    private bool nextClicked;
    private Typewriter typewriter;
    public bool tutorialCompleted;

    public float EnterYDelta;

    public Coroutine StartTutorial()
    {
        gameObject.SetActive(true);
        typewriter = this.GetComponent<Typewriter>();
        coroutine = StartCoroutine(RunConversation());
        return coroutine;
    }

    public void DirectionsClick()
    {
        nextClicked = true;
    }

    public void SkipTutorial()
    {
        StopCoroutine(coroutine);
        coroutine = null;
        gameObject.SetActive(false);
    }

    public IEnumerator RunConversation()
    {
        yield return new WaitForSeconds(.75f);
        character.SetActive(true);
        yield return GetComponent<RectTransform>()
            .DOAnchorPosY(EnterYDelta, .75f)
            .From()
            .SetEase(Ease.OutQuint)
            .WaitForCompletion();
        yield return new WaitForSeconds(.4f);
        bubble.SetActive(true);
        foreach (string d in directions)
        {
            continueButton.SetActive(false);
            yield return typewriter.PlayText(d);
            continueButton.SetActive(true);
            yield return WaitForNextClick();
        }
        bubble.SetActive(false);
        yield return new WaitForSeconds(.4f);
        yield return GetComponent<RectTransform>()
            .DOAnchorPosY(EnterYDelta, .75f)
            .SetEase(Ease.InQuint)
            .WaitForCompletion();
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
