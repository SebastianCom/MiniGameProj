using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GDGameTimer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] EnemiesThisLevel;
    public List<GameObject> EnemiesAlive;

    public float DropTime = 20.0f;

    private float _gameTimer = 0.0f;

    void Start()
    {
        EnemiesThisLevel = GameObject.FindGameObjectsWithTag("Enemy");

        for(int i = 0; i < EnemiesThisLevel.Length; i++) 
        {
            EnemiesAlive.Add(EnemiesThisLevel[i]);
        }
    }

    public void RemoveEnemy(GameObject Enemy)
    {
        EnemiesAlive.Remove(Enemy);
    }

    // Update is called once per frame
    void Update()
    {
        if(_gameTimer >= DropTime)
        {
            foreach(GameObject obj in EnemiesAlive) 
            {
                obj.GetComponent<GDBasicEnemy>().TriggerMoveDown();
            }

            _gameTimer = 0.0f;
        }
        else
        {
            _gameTimer += Time.deltaTime;
        }
    }
}
