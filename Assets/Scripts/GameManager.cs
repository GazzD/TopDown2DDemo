using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int lifes = 3;
    public readonly int MAX_LIFES = 8;
    public float invincibilityTime = 3f;
    public bool isInvincible = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }

    public void GameOver()
    {
        HUDManager.Instance.HideInterface();
        SceneLoadManager.Instance.GameOver();
        //PlayerLife.Instance.Destroy();
    }

    public void NewGame()
    {
        ResetLifes();
        //HUDManager.Instance?.UpdateHearts();
        SceneLoadManager.Instance?.NewGame();
        HUDManager.Instance?.ShowInterface();
    }

    [ContextMenu("Add Life")]
    public void AddLife()
    {
        print(lifes);
        print(MAX_LIFES);
        if (lifes + 1 <= MAX_LIFES)
        {
            lifes++;
            HUDManager.Instance.UpdateHearts();
        }
        else
        {
            print("MAX LIFES REACHED");
        }

    }

    [ContextMenu("Remove Life")]
    public void RemoveLife()
    {
        print(lifes);

        if (isInvincible) return; // If the player is invincible, don't remove life

        if (lifes - 1 > 0)
        {
            lifes--;
            HUDManager.Instance.UpdateHearts();
            StartCoroutine(Invulnerability());
        }
        else
        {
            Destroy(gameObject);
            GameManager.Instance.GameOver();
        }

    }

    public void ResetLifes()
    {
        lifes = 3;
    }


    


    IEnumerator Invulnerability()
    {
        isInvincible = true;
        yield return new WaitForSeconds(invincibilityTime);
        isInvincible = false;
    }
}
