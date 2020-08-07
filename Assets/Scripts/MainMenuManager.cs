using UnityEngine;
using DG.Tweening;

public class MainMenuManager : MonoBehaviour
{
    public GameObject lightning;
    public Animator bats1;
    public Animator bats2;

    void Start()
    {
        DOTween.Sequence()
            .AppendInterval(2)
            .AppendCallback(() => lightning.SetActive(true))
            .AppendCallback(() => bats1.Play("Fly", -1, 0))
            .AppendInterval(.03f)
            .AppendCallback(() => lightning.SetActive(false))
            .AppendInterval(.12f)
            .AppendCallback(() => lightning.SetActive(true))
            .AppendInterval(.03f)
            .AppendCallback(() => lightning.SetActive(false))
            .AppendInterval(5)
            .AppendCallback(() => bats2.Play("Fly", -1, 0))
            .AppendInterval(3)
            .SetLoops(-1);
    }
}
