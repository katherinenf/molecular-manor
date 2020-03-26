using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BgScroller : MonoBehaviour
{
    public Texture texture;
    public Vector2 scrollRate;

    RawImage _image;

    void Start()
    {
        float aspect = Screen.height / (float)Screen.width;
        float width = Screen.width / (float)texture.width;

        _image = gameObject.AddComponent<RawImage>();
        _image.texture = texture;
        _image.uvRect = new Rect(0.0f, 0.0f, width, width * aspect);
    }

    void Update()
    {
        var rect = _image.uvRect;
        rect.position = scrollRate * Time.time;
        _image.uvRect = rect;
    }
}
