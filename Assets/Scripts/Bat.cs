using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bat : MonoBehaviour
{
    public Sprite[] frames = new Sprite[2];
    public float frameTime;
    public float startOffset;
    Image img;
    int idx;

    void Start()
    {
        img = GetComponent<Image>();
        StartCoroutine(PlayAnimation());
    }

    IEnumerator PlayAnimation()
    {
        idx = (int)((frames.Length-1) * Mathf.Clamp(startOffset / frameTime, 0f, 1f));
        while (true)
        {
            img.sprite = frames[idx++ % frames.Length];
            yield return new WaitForSeconds(frameTime + startOffset);
            startOffset = 0;
        }
    }
}
