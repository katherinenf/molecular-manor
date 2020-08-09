using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class EndManager : MonoBehaviour
{
    public ParticleSystem emitter;
    public Button chestBtn;
    public GameObject openChest;
    public GameObject closedChest;
    public Image closedMask;
    public GameObject winText;
    public GameObject gameOver;
    public Fader fader;

    public void OnChestClicked()
    {
        chestBtn.interactable = false;
        emitter.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        DOTween.Sequence()
            .Append(closedChest.transform.DOScale(.85f, 1.25f).SetEase(Ease.OutQuint))
            .Insert(0, closedMask.DOFade(1f, 1f).SetEase(Ease.InOutCirc))
            .Insert(0, closedChest.GetComponent<RectTransform>()
                .DOShakeRotation(1.25f, new Vector3(0, 0, 6), 60, 90, true)
            )
            .AppendCallback(() =>
            {
                closedChest.SetActive(false);
                openChest.SetActive(true);
                winText.SetActive(true);
            })
            .Append(openChest.transform
                .DOShakeScale(1, .15f)
                .SetEase(Ease.OutQuart)
            )
            .Insert(1.25f, winText
                .transform.DOScale(1f, 1f)
                .SetEase(Ease.OutQuint)
            )
            .Insert(1.25f, winText.GetComponent<RectTransform>()
                .DOAnchorPosY(400, 1f)
                .SetRelative()
                .SetEase(Ease.OutQuint)
            )
            .AppendInterval(1.5f)
            .AppendCallback(() => gameOver.SetActive(true));
    }


    public void OnRestartClicked()
    {
        Globals.ResetProgress();
        fader.FadeOut("MainMenuScene");
    }
}
