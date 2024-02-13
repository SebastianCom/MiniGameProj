using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GDLevelManager : MonoBehaviour
{
    public List<GameObject> Levels = new List<GameObject>();
    public List<GameObject> CurrentEnemies;
    public GameObject StartScreen;
    public TextMeshProUGUI CoundDownText;

    public bool GameStarted = false;

    public int CurrentLevel = 0;

    bool CountDown = false;
    float TimeBeforeStart = 6;
    // Start is called before the first frame update
    void Start()
    {
        GetEnemiesForLevel(Levels[0]);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameStarted) 
        {
            if(CurrentEnemies.Count <= 0)
            {
                GameStarted = false;
                CurrentLevel++;
                NextLevel(CurrentLevel);
            }
        }
        else if(CountDown)
        {
            int TimeToShow = (int)TimeBeforeStart;
            CoundDownText.text = TimeToShow.ToString();
            if(TimeBeforeStart <= 1)
            {
                GameStarted = true;
                TimeBeforeStart = 6.0f;
                CountDown = false;
                CoundDownText.gameObject.SetActive(false);
            }
            else
            {
                TimeBeforeStart -= Time.deltaTime;
            }
        }
    }

    public void GetEnemiesForLevel(GameObject level)
    {
        for(int i = 0; i < level.transform.childCount; i++) 
        {
            CurrentEnemies.Add(level.transform.GetChild(i).gameObject);

        }
    }

    public void NextLevel(int index)
    {
        if(Levels.Count >= index) 
        {
            Levels[index].SetActive(true);
            
            GetEnemiesForLevel((GameObject)Levels[index]);
            FindAnyObjectByType<GDGameTimer>()._gameTimer = 0.0f;

            GameStarted = true;
        }

       
    }

    public void StartGame()
    {
        CountDown = true;
        StartScreen.SetActive(false);
        CoundDownText.gameObject.SetActive(true);

    }
}
