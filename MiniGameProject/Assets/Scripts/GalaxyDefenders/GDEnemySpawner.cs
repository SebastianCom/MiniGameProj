using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GDEnemySpawner : MonoBehaviour
{
    public List<GameObject> Spots;
    public List<GameObject> EnemiesSpawned;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [ContextMenu("Generate Ships")]
    public void GenerateShips()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Spots.Add(transform.GetChild(i).gameObject);
        }

        foreach (GameObject spot in Spots) 
        {
            EnemiesSpawned.Add(Instantiate(spot.GetComponent<GDSpot>().Enemy, spot.transform));
            
        }
    }

    [ContextMenu("Destroy Ships")]
    public void DestroyShips()
    {

        foreach (GameObject Enemey in EnemiesSpawned)
        {
            DestroyImmediate(Enemey);

        }
        EnemiesSpawned.Clear();
        Spots.Clear();
    }
}
