using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public static HUDManager Instance { get; private set; }

    public GameObject fullHearth;
    public GameObject halfHearth;
    public GameObject emptyHearth;

    private void Awake()
    {
        print("HUDManager Awake");
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
    private void FixedUpdate()
    {
        UpdateHearts();
    }

    public void UpdateHearts()
    {
        //print("UpdateHearts");

        Image[] childHearts = GetComponentsInChildren<Image>();

        int hearthContainers = childHearts.Length;

        //print("ChildHearts: " + hearthContainers + " Lifes: " + PlayerLife.Instance.lifes);
        // Clear all hearts
        for (int i = 0; i < hearthContainers; i++)
        {
            //print("Clear hearth");
            childHearts[i].sprite = emptyHearth.GetComponent<Image>().sprite;
        }
        if (GameManager.Instance != null && childHearts != null && GameManager.Instance.lifes >= 0 && GameManager.Instance.lifes <= GameManager.Instance.MAX_LIFES) { 
            
            //if (PlayerLife.Instance != null)
            //{
                // Adds full hearts (2 lifes = 1 hearth)
                for (int i = 0; i < GameManager.Instance.lifes / 2; i++)
                {
                    //print("Add Full hearth");
                    childHearts[i].sprite = fullHearth.GetComponent<Image>().sprite;
                    childHearts[i].GameObject().SetActive(true);
                }

                // Adds half heart if lifes are odd
                if (GameManager.Instance.lifes % 2 != 0)
                {
                    //print("Add Half hearth");
                    int position = (GameManager.Instance.lifes + 1) / 2;
                    childHearts[(GameManager.Instance.lifes) / 2].sprite = halfHearth.GetComponent<Image>().sprite;
                }

                // Deactivates the rest of the hearts
                for (int i = GameManager.Instance.MAX_LIFES / 2; i < hearthContainers; i++)
                {
                    childHearts[i].GameObject().SetActive(false);
                }
            //}
        }
        else
        {
            print("Something is wrong...");
        }
       
    }

    public void HideInterface()
    {
        //print("Hide Interface");
        gameObject.SetActive(false);
    }
    public void ShowInterface()
    {
        //print("Show Interface");
        gameObject.SetActive(true);

    }
}
