using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;
using UnityEngine.Localization.SmartFormat.PersistentVariables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class HUDManager : MonoBehaviour
{
    public static HUDManager Instance { get; private set; }

    public GameObject fullHearth;
    public GameObject halfHearth;
    public GameObject emptyHearth;


    [SerializeField] private LocalizedString  localStringScore;
    [SerializeField] private TextMeshProUGUI textComp;

    private void Awake()
    {
        print("HUDManager Awake");
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
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
        UpdateScore();
    }

    private void OnEnable()
    {
        localStringScore.Arguments = new object[] { GameManager.Instance?.Score };
        localStringScore.StringChanged += UpdateScoreLabel;
        //localStringScore.Add("score", new IntVariable { Value = 0 });
        

    }
    private void OnDisable()
    {
        localStringScore.StringChanged -= UpdateScoreLabel;
    }

    private void UpdateScoreLabel(string value)
    {
        textComp.text = value;
    }

    [ContextMenu("Update Score")]
    public void UpdateScore()
    {
        
        localStringScore.Arguments[0] = GameManager.Instance.Score;
        localStringScore.RefreshString();

        // Get subtitle text
        //TextMeshProUGUI textToUpdate = uiElement.GetComponent<DataRTElement>().SubtitleUi;

        // Setup LocalizeStringEvent
        //LocalizedString localizeString = new LocalizedString(data.DataRTValueLocalizer.TableName, data.DataRTValueLocalizer.SubtitleLocalized);

        // Add local variables to update
        //localStringScore.Add("variable.score", new IntVariable { Value = GameManager.Instance.score });
        //localizeString.Add("unitTime", new StringVariable { Value = "min" });

        //uiElement.GetComponent<LocalizeStringEvent>().StringReference = localizeString;
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
