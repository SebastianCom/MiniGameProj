using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum SpawnType
{
    None,
    Vehicle,
    Platform
}

public class Frogger_LaneInfo : MonoBehaviour
{
    public Vector3 LeftSpawner = Vector3.zero;
    public Vector3 RightSpawner = Vector3.zero;
    public bool SpawningLane = false;
    public bool Water = false;
    public bool End = false;
    public bool SpawnLeft = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
