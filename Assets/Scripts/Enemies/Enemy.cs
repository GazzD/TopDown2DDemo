using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject dieEffect;
    [SerializeField] private float maxHealth;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private int enemyScore = 10;


    private float currentHealth;
    private SpriteRenderer spriteRenderer;
    private Color originalColor = Color.blue;
    private Animator animator;

    private const string IS_TAKING_DAMAGE = "IsTakingDamage";

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.UpdateHealthBar(maxHealth, currentHealth, maxHealth);
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();
    }

    public void TakeDamage()
    {
        float damageDuration = 0.1f;
        float previousHealth = currentHealth;
        currentHealth -= 1;
        if (currentHealth > 0)
        { 
            animator.SetBool(IS_TAKING_DAMAGE, true);
            healthBar.UpdateHealthBar(maxHealth, currentHealth, previousHealth);
            spriteRenderer.color = Color.red;
            Invoke("ResetColor", damageDuration);
        }
        else
        {
            GameManager.Instance.AddScore(enemyScore);
            Instantiate(dieEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void ResetColor()
    {
        spriteRenderer.color = originalColor;
        animator.SetBool(IS_TAKING_DAMAGE, false);
    }


}
