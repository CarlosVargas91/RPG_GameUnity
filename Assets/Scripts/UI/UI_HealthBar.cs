using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_HealthBar : MonoBehaviour
{
    private Entity entity;
    private CharacterStats myStats;
    private RectTransform myTransform;
    private Slider slider;

    private void Start()
    {
        myTransform = GetComponent<RectTransform>();
        entity = GetComponentInParent<Entity>();
        slider = GetComponentInChildren<Slider>();
        myStats = GetComponentInParent<CharacterStats>();

        entity.onFlipped += flipUI; //Add something to the event
        myStats.onHealthChanged += updateHealthUI;

        updateHealthUI();
    }

    private void updateHealthUI()
    {
        slider.maxValue = myStats.getMaxHealthValue();
        slider.value = myStats.currentHealth;
    }
    private void flipUI() => myTransform.Rotate(0, 180, 0); //Remove rotation of UI bar

    private void OnDisable()
    {
        entity.onFlipped -= flipUI; //Unsubscribe from event
        myStats.onHealthChanged -= updateHealthUI;
    }
}
