using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteToUI : MonoBehaviour
{
    public RawImage uiImage;
    public SpriteRenderer spriteRenderer;

    void Update()
    {
        uiImage.texture = spriteRenderer.sprite.texture;
    }
}
