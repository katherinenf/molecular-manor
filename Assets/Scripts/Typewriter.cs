using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Typewriter : MonoBehaviour
{
    public Text directionText;

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator PlayText(string direction)
    {
        directionText.text = "";
        foreach(char c in direction)
        {
            directionText.text += c;
            float timer = 0.1f;
            while(timer > 0)
            {
                if (Input.anyKey)
                {
                    directionText.text = direction;
                    yield break;
                }
                yield return null;
                timer -= Time.deltaTime;
            }
        }
    }
}
