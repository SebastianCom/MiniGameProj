using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GDGameTimer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] EnemiesThisLevel;
    //public List<GameObject> EnemiesAlive;

    public GDLevelManager LevelManager;

    public float DropTime = 20.0f;

    public float _gameTimer = 0.0f;

    public bool bTimerRunning = true;

    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindAnyObjectByType<GDLevelManager>().GameStarted == true)
        {
            if (bTimerRunning)
            {
                if (_gameTimer >= DropTime)
                {
                    foreach (GameObject obj in LevelManager.CurrentEnemies)
                    {
                        obj.GetComponent<GDBasicEnemy>().TriggerMoveDown();
                    }

                    _gameTimer = 0.0f;

                    bTimerRunning = false;
                }
                else
                {
                    _gameTimer += Time.deltaTime;
                }
            }
        }


    }
}
