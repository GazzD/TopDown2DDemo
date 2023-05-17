using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int lifes = 3;
    public int currentMaxLifes = 4;
    public readonly int MAX_LIFES = 8;
    public float invincibilityTime = 3f;
    public bool isInvincible = false;
    public int Score { get; private set; }
    public bool IsPaused { get; private set; }

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
    
    public void ResumeGame()
    {
        IsPaused = false;
    }

    public void PauseGame()
    {
        IsPaused = true;
    }

    public void GameOver()
    {
        HUDManager.Instance.HideInterface();
        SceneLoadManager.Instance.GameOver();
        //PlayerLife.Instance.Destroy();
    }

    public void NewGame()
    {
        ResetProps();
        //HUDManager.Instance?.UpdateHearts();
        SceneLoadManager.Instance?.NewGame();
        HUDManager.Instance?.ShowInterface();
    }

    public void AddScore(int amount)
    {
        Score += amount;
        HUDManager.Instance.UpdateScore();
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
            GameOver();
        }

    }

    public void ResetProps()
    {
        lifes = 3;
        Score = 0;
        IsPaused = false;
    }

    IEnumerator Invulnerability()
    {
        isInvincible = true;
        yield return new WaitForSeconds(invincibilityTime);
        isInvincible = false;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public void Test()
    {
        print("Test");
    }
}
