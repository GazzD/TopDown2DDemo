using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageLoader : MonoBehaviour
{
    [SerializeField] private string levelName;

    private void OnTriggerEnter2D(Collider2D other)
    {
        print(other.tag);

        if (other.CompareTag("Player"))
        {
            StartCoroutine(SceneLoadManager.Instance.SceneLoad(levelName));
            
        }
    }
}
