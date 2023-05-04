using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(SceneLoadManager.Instance.SceneLoad(SceneLoadManager.MAIN_TITLE));
        }
    }
}
