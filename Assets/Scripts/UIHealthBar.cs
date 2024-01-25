using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    public static UIHealthBar instance { get; private set; }

    public TMP_Text tmp;
    public Image mask;
    private float originalSize;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        originalSize = mask.rectTransform.rect.width;
    }

    public void SetValue(float currentHealth, int maxHealth)
    {
        var value = currentHealth / (float)maxHealth;
        mask.rectTransform.SetSizeWithCurrentAnchors(
            RectTransform.Axis.Horizontal,
            originalSize * value);

        tmp.text = $"{currentHealth} / {maxHealth}";
    } 
}
