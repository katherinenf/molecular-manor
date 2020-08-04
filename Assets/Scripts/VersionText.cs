using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VersionText : MonoBehaviour
{
    void Start()
    {
        TMP_Text uiText = GetComponent<TMP_Text>();
        if (uiText != null)
        {
            uiText.text = "v" + Application.version;
        }
    }
}
