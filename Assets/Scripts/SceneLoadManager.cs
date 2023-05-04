using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{

    public static readonly string MAIN_TITLE = "MainTitle";
    public static readonly string GAME = "Game";
    public static readonly string LEVEL_1 = "Level1";
    public static readonly string LEVEL_2 = "Level2";
    public static readonly string LEVEL_3 = "Level3";
    public static readonly string GAME_OVER = "GameOver";
    public static readonly string END_GAME = "EndGame";
    public static SceneLoadManager Instance { get; private set; }
    [SerializeField] private float transitionTime = 1f;

    private Animator animator;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            //DontDestroyOnLoad(this);
        }
    }

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void LoadNextScene()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        StartCoroutine(SceneLoad(nextSceneIndex));
    }

    public void NewGame()
    {
        StartCoroutine(SceneLoad(GAME));
    }


    public IEnumerator SceneLoad(int sceneIndex)
    {
        animator.SetTrigger("StartTransition");
        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(sceneIndex);

    }

    public IEnumerator SceneLoad(string sceneName)
    {
        animator.SetTrigger("StartTransition");
        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(sceneName);

    }

    public void GameOver()
    {
        StartCoroutine(SceneLoad(GAME_OVER));
    }
}
