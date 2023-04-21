using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image barImage;

    public void UpdateHealthBar(float maxHealth, float health, float previousHealth)
    {
        float targetHealth = health / maxHealth;
        previousHealth = previousHealth / maxHealth;
        StartCoroutine(HealthBarAnimation(targetHealth, previousHealth));
        
    }

    private IEnumerator HealthBarAnimation(float targetHealth, float previousHealth)
    {
        float transitionTime = 0.5f, elapsedTime = 0f;
        while (elapsedTime < transitionTime)
        {
            elapsedTime += Time.deltaTime;
            barImage.fillAmount = Mathf.Lerp(previousHealth, targetHealth, elapsedTime / transitionTime);
            yield return null;
        }
        barImage.fillAmount = targetHealth;
    }
}
