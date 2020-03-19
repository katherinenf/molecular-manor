using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fader : MonoBehaviour
{
    public RawImage fadeInImage;
    public RawImage fadeOutImage;
    public float fadeInDuration;
    public float fadeOutDuration;
    public float fadeInDegPerSec;
    public float fadeOutDegPerSec;
    public AnimationCurve curve;
    public bool fadeInOnAwake;

    void Start()
    {
        if (fadeInOnAwake)
        {
            StartCoroutine(PlayFadeIn());
        }
    }

    public void FadeOut(string scene, Vector3 position = new Vector3())
    {
        transform.position = position;
        StartCoroutine(PlayFadeOut(scene));
    }

    IEnumerator PlayFadeOut(string sceneName)
    {
        fadeOutImage.gameObject.SetActive(true);
        transform.Rotate(new Vector3(0f, 0f, -fadeOutDegPerSec * fadeOutDuration));
        float curTime = 0f;
        while (curTime < fadeOutDuration)
        {
            curTime += Time.deltaTime;
            float lerp = curve.Evaluate(curTime / fadeOutDuration);
            Rect rect = new Rect();
            rect.width = Mathf.Lerp(1f, 55f, lerp);
            rect.height = Mathf.Lerp(1f, 55f, lerp);
            rect.x = .5f - rect.width / 2.0f;
            rect.y = .5f - rect.height / 2.0f;
            fadeOutImage.uvRect = rect;
            transform.Rotate(new Vector3(0f, 0f, fadeOutDegPerSec * Time.deltaTime));
            yield return null;
        }
        fadeOutImage.texture = null;
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
    }

    IEnumerator PlayFadeIn()
    {
        fadeInImage.gameObject.SetActive(true);
        transform.Rotate(new Vector3(0f, 0f, -fadeInDegPerSec * fadeInDuration));
        float curTime = 0f;
        while (curTime < fadeInDuration)
        {
            curTime += Time.deltaTime;
            Rect rect = new Rect();
            rect.width = Mathf.Lerp(1f, 70f, 1.0f - curTime / fadeInDuration);
            rect.height = Mathf.Lerp(1f, 70f, 1.0f - curTime / fadeInDuration);
            rect.x = .5f - rect.width / 2.0f;
            rect.y = .5f - rect.height / 2.0f;
            fadeInImage.uvRect = rect;
            transform.Rotate(new Vector3(0f, 0f, fadeInDegPerSec * Time.deltaTime));
            yield return null;
        }
        fadeInImage.gameObject.SetActive(false);
    }
}
