using UnityEngine;
using DG.Tweening;

public class DoorIndicator : MonoBehaviour
{
    void Start()
    {
        GetComponent<RectTransform>()
            .DOAnchorPosY(10, .75f)
            .SetRelative()
            .SetEase(Ease.InOutSine)
            .SetLoops(-1, LoopType.Yoyo);
    }
}
