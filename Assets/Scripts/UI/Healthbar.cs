using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Healthbar : MonoBehaviour
    {
        public static Healthbar instance { get; private set; }

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
}