using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public Sprite fullSprite;
    public Sprite okSprite;
    public Sprite stressSprite;
    public Sprite criticSprite;

    public GameObject handle;
    private Image image;

    public void Start()
    {
        image = handle.GetComponent<Image>();
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;

        if (slider.value >= 40)
        {
            image.sprite = fullSprite;
        }
        else if (slider.value >= 30)
        {
            image.sprite = okSprite;
        }
        else if (slider.value >= 20)
        {
            image.sprite = stressSprite;
        }
        else
        {
            image.sprite = criticSprite;
        }
    }
}
