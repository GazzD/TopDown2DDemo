using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    //public static PlayerLife Instance { get; private set; }

    //public int lifes = 3;

    //public readonly int MAX_LIFES = 8;

    //private void Awake()
    //{
    //    if (Instance != null && Instance != this)
    //    {
    //        Destroy(this);
    //    }
    //    else
    //    {
    //        Instance = this;
    //        //DontDestroyOnLoad(this);
    //    }
    //}

    //[ContextMenu("Add Life")]
    //public void AddLife()
    //{
    //    print(lifes);
    //    print(MAX_LIFES);
    //    if (lifes + 1 <= MAX_LIFES)
    //    {
    //        lifes++;
    //        HUDManager.Instance.UpdateHearts();
    //    } else
    //    {
    //        print("MAX LIFES REACHED");
    //    }

    //}

    //[ContextMenu("Remove Life")]
    //public void RemoveLife()
    //{
    //    print(lifes);
    //    if (lifes - 1 > 0)
    //    {
    //        lifes--;
    //        HUDManager.Instance.UpdateHearts();
    //    } 
    //    else
    //    {
    //        Destroy(gameObject);
    //        GameManager.Instance.GameOver();
    //    }
    //}

    //public void ResetLifes()
    //{
    //    lifes = 3;
    //}
}
