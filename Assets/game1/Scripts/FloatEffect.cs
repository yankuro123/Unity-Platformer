using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatEffect : MonoBehaviour
{
    private float starty = 0f;
    private float duration = 1f;
    private RectTransform  RTransform;
    // Start is called before the first frame update
    void Start()
    {
        RTransform = GetComponent<RectTransform>();
        starty = RTransform.anchoredPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        var newY = starty + (starty + Mathf.Cos(Time.time / duration * 2)) / .1f;
        RTransform.anchoredPosition = new Vector2(RTransform.anchoredPosition.x, newY);
    }
}
