using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Frogger_SpriteAnimator : MonoBehaviour
{
    public Sprite[] frames;
    public float framesPerSecond = 10f;

    private Image spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<Image>();
        InvokeRepeating("NextFrame", 0, 1 / framesPerSecond);
    }

    private void NextFrame()
    {
        int index = (int)(Time.time * framesPerSecond) % frames.Length;
        spriteRenderer.sprite = frames[index];
    }
}
