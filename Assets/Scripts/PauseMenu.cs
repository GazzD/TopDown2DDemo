using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanel;

    private PlayerInput playerInput;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        if (GameInput.Instance.GetPauseInputDown())
        {
            if (PausePanel.activeSelf)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        print("Pause");
        PausePanel.SetActive(true);
        GameManager.Instance.PauseGame();
        Time.timeScale = 0;
    }

    public void Resume()
    {
        print("Resume");
        PausePanel.SetActive(false);
        GameManager.Instance.ResumeGame();
        Time.timeScale = 1;
    }

    public void MainTitle()
    {
        print("Main titkle");
        HUDManager.Instance.HideInterface();
        GameManager.Instance.Destroy();
        Resume();
        StartCoroutine(SceneLoadManager.Instance.SceneLoad(SceneLoadManager.MAIN_TITLE));
    }

}
