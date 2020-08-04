using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Character : MonoBehaviour
{
    public List<string> directions;
    public GameObject character;
    public GameObject bubble;
    public GameObject bubbleBG;
    public GameObject continueButton;
    public GameObject skipButton;
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
        yield return AnimateCharacterIn();
        yield return AnimateBubbleIn();

        // Show the tutorial one at a time
        foreach (string d in directions)
        {
            continueButton.SetActive(false);
            yield return typewriter.PlayText(d);
            continueButton.SetActive(true);
            skipButton.SetActive(true);
            yield return WaitForNextClick();
        }

        yield return AnimateBubbleOut();
        yield return AnimateCharacterOut();
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

    public IEnumerator AnimateCharacterIn()
    {
        character.SetActive(true);
        yield return character.GetComponent<RectTransform>()
            .DOAnchorPosY(EnterYDelta, 1f)
            .From()
            .SetEase(Ease.OutQuint)
            .WaitForCompletion();
    }

    public IEnumerator AnimateCharacterOut()
    {
        yield return character.GetComponent<RectTransform>()
            .DOAnchorPosY(EnterYDelta, .5f)
            .SetEase(Ease.InCubic)
            .WaitForCompletion();
        character.SetActive(false);
    }

    public IEnumerator AnimateBubbleIn()
    {
        skipButton.SetActive(false);
        continueButton.SetActive(false);
        typewriter.Clear();
        bubble.SetActive(true);
        yield return bubbleBG.transform
            .DOScale(0, .35f)
            .From()
            .SetEase(Ease.OutQuad)
            .WaitForCompletion();
    }

    public IEnumerator AnimateBubbleOut()
    {
        skipButton.SetActive(false);
        continueButton.SetActive(false);
        typewriter.Clear();
        yield return bubbleBG.transform
            .DOScale(0, .3f)
            .SetEase(Ease.InOutQuad)
            .WaitForCompletion();
        bubble.SetActive(false);
    }

}
